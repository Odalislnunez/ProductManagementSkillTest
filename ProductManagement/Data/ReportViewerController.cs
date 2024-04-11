using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Data
{
    using BoldReports.Web;
    using BoldReports.Web.ReportViewer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Caching.Memory;
    using ProductManagement.Core.Models;
    using ProductManagement.Core.Services.Interfaces;

    namespace BlazorReportingTools.Data
    {
        [Route("api/{controller}/{action}/{id?}")]
        public class ReportViewerController : ControllerBase, IReportController
        {
            // Report viewer requires a memory cache to store the information of consecutive client requests and
            // the rendered report viewer in the server.
            private IMemoryCache _cache;

            // IWebHostEnvironment used with sample to get the application data from wwwroot.
            private IWebHostEnvironment _hostingEnvironment;
            private IGeneridCrudService<Customer> _customerService;
            private IGeneridCrudExtService<Item> _itemService;
            private IGeneridCrudExtService<CustomerItem> _customerItemService;

            public ReportViewerController(
                IMemoryCache memoryCache,
                IWebHostEnvironment hostingEnvironment,
                IGeneridCrudService<Customer> customerService,
                IGeneridCrudExtService<Item> itemService,
                IGeneridCrudExtService<CustomerItem> customerItemService
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
                MemoryStream reportStream = new MemoryStream();
                fileStream.CopyTo(reportStream);
                reportStream.Position = 0;
                fileStream.Close();
                reportOption.ReportModel.Stream = reportStream;

                switch (reportOption.ReportModel.ReportPath)
                {
                    case Const.GlobalVariables.Customer:
                        reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "CustomerDataSet", Value = (List<Customer>)await _customerService.GetAll() });
                        break;
                    case Const.GlobalVariables.Item:
                        reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "ItemsDataSet", Value = (List<Item>)await _itemService.GetAll() });
                        break;
                    case Const.GlobalVariables.CustomerItem:
                        reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "CustomerItemDataSet", Value = (List<CustomerItem>)await _customerItemService.GetAll() });
                        break;
                    default: break;
                }
            }

            // Method will be called when report is loaded internally to start the layout process with ReportHelper.
            [NonAction]
            public void OnReportLoaded(ReportViewerOptions reportOption)
            {
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
                return ReportHelper.ProcessReport(jsonArray, this, this._cache);
            }
        }
    }
}
