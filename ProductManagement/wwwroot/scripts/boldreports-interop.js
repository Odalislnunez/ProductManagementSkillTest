// Interop file to render the Bold Report Viewer component with properties.
window.BoldReports = {
    RenderViewer: function (elementID, reportViewerOptions) {
        console.log(reportViewerOptions);
        $("#" + elementID).boldReportViewer({
            reportPath: reportViewerOptions.reportPath,
            reportServiceUrl: reportViewerOptions.reportServiceURL,
            parameters: reportViewerOptions.parameters
        });
    }
}