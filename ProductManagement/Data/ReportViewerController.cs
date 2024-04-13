namespace ProductManagement.Data
{
    using BoldReports.Web;
    using BoldReports.Web.ReportViewer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using ProductManagement.Core.Models;
    using ProductManagement.Core.Services.Interfaces;
    using System.Collections.Generic;

    namespace BlazorReportingTools.Data
    {
        [Route("api/{controller}/{action}/{id?}")]
        public class ReportViewerController : ControllerBase, IReportController
        {
            private Dictionary<string, object> jsonA;
            private int item1 = 0, item2 = 0;

            // Report viewer requires a memory cache to store the information of consecutive client requests and
            // the rendered report viewer in the server.
            private IMemoryCache _cache;

            // IWebHostEnvironment used with sample to get the application data from wwwroot.
            private IWebHostEnvironment _hostingEnvironment;
            private IGeneridCrudService<Customer> _customerService;
            private IGeneridCrudExtService<Item> _itemService;
            private IGeneridCrudExt2Service<CustomerItem> _customerItemService;

            public ReportViewerController(
                IMemoryCache memoryCache,
                IWebHostEnvironment hostingEnvironment,
                IGeneridCrudService<Customer> customerService,
                IGeneridCrudExtService<Item> itemService,
                IGeneridCrudExt2Service<CustomerItem> customerItemService
                )
            {
                _cache = memoryCache;
                _hostingEnvironment = hostingEnvironment;
                _customerService = customerService;
                _itemService = itemService;
                _customerItemService = customerItemService;
            }
            //Get action for getting resources from the report
            [ActionName("GetResource")]
            [AcceptVerbs("GET")]
            // Method will be called from Report Viewer client to get the image src for Image report item.
            public object GetResource(ReportResource resource)
            {
                return ReportHelper.GetResource(resource, this, _cache);
            }

            // Method will be called to initialize the report information to load the report with ReportHelper for processing.
            [NonAction]
            public async void OnInitReportOptions(ReportViewerOptions reportOption)
            {
                reportOption.ReportModel.ProcessingMode = ProcessingMode.Local;
                string basePath = Path.Combine(_hostingEnvironment.WebRootPath, "Resources");
                string reportPath = Path.Combine(basePath, reportOption.ReportModel.ReportPath);

                FileStream fileStream = new FileStream(reportPath, FileMode.Open, FileAccess.Read);
                reportOption.ReportModel.Stream = fileStream;
            }

            // Method will be called when report is loaded internally to start the layout process with ReportHelper.
            [NonAction]
            public async void OnReportLoaded(ReportViewerOptions reportOption)
            {
                var reportParameters = ReportHelper.GetParametersWithValues(jsonA, this, _cache);
                List<ReportParameter> modifiedParameters = new List<ReportParameter>();
                if (reportParameters != null)
                {
                    foreach (var rptParameter in reportParameters)
                    {
                        modifiedParameters.Add(new ReportParameter()
                        {
                            Name = rptParameter.Name,
                            Values = (List<string>)rptParameter.Values,
                            Hidden = true
                        });
                    }
                    reportOption.ReportModel.Parameters = modifiedParameters;
                }

                reportOption.ReportModel.DataSources.Clear();

                switch (reportOption.ReportModel.ReportPath)
                {
                    case Const.GlobalVariables.Customer:
                        reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "CustomerDataSet", Value = (List<Customer>)await _customerService.GetAll() });
                        break;
                    case Const.GlobalVariables.Item:
                        reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "ItemsDataSet", Value = (List<Item>)await _itemService.GetAll() });
                        break;
                    case Const.GlobalVariables.CustomerItem:
                        item1 = Convert.ToInt32(reportOption.ReportModel.Parameters?.Where(x => x.Name == "item1").FirstOrDefault()?.Values.FirstOrDefault());
                        item2 = Convert.ToInt32(reportOption.ReportModel.Parameters?.Where(x => x.Name == "item2").FirstOrDefault()?.Values.FirstOrDefault());

                        var customerItem = new List<CustomerItem>();

                        if (item1 > 0 && item2 > 0)
                            customerItem = (List<CustomerItem>)await _customerItemService.GetAll(item1, item2);
                        else
                            customerItem = (List<CustomerItem>)await _customerItemService.GetAll();

                        var customers = customerItem.Select(x => new Customer
                        {
                            Name = x.Customer.Name
                        }).ToList();

                        var items = customerItem.Select(x => new Item
                        {
                            Id = x.ItemId,
                            Description = x.Item.Description
                        }).ToList();

                        var reportDataSources = new List<(string Name, object Value)>
                        {
                            ("CustomersDataSet", customers),
                            ("ItemsDataSet", items),
                            ("CustomerItemDataSet", customerItem)
                        };

                        reportDataSources.ForEach(dataSource =>
                        {
                            reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = dataSource.Name, Value = dataSource.Value });
                        });
                        break;
                    default: break;
                }
            }

            [HttpPost]
            public object PostFormReportAction()
            {
                return ReportHelper.ProcessReport(null, this, _cache);
            }

            // Post action to process the report from the server based on json parameters and send the result back to the client.
            [HttpPost]
            public object PostReportAction([FromBody] Dictionary<string, object> jsonArray)
            {
                jsonA = jsonArray;

                return ReportHelper.ProcessReport(jsonArray, this, this._cache);
            }
        }
    }
}
