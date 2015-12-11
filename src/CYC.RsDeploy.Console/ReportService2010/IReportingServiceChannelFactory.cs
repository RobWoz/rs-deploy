namespace CYC.RsDeploy.Console.ReportService2010
{
    public interface IReportingServiceChannelFactory
    {
        IReportingService2010 Create(string url);
    }
}