namespace Rs.Services
{
    public interface IFileService
    {
        byte[] GetBytes(string file);
        string GetReportingServicesItemType(string file);
    }
}