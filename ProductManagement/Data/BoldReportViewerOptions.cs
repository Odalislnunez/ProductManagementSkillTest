using BoldReports.Web;

namespace ProductManagement.Data
{
    public class BoldReportViewerOptions
    {
        public string ReportPath { get; set; }  
        public string ReportServiceURL { get; set; }
        public List<ReportParameter> Parameters { get; set; }
    }
}
