using PatronFactory.Interfaces;
using PatronFactory.Services;

namespace PatronFactory.Factories
{
    public class ReportGeneratorFactory
    {
        public ReportGeneratorFactory() { }

        public static IUserFiles ServicesFactory(string service) => service.ToLower() switch
        {
            "csv" => new ReportCsv(),
            "pdf" => new ReportPdf(),
            "xlsx" => new ReportExcel()
        };
    }
}
