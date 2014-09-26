using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Rs.ReportService2010
{
    public class ReportingServiceChannelFactory
    {
        public IReportingService2010 Create(string url)
        {
            var endpoint = new EndpointAddress(url);
            var binding = endpoint.Uri.Scheme == "https" ? new BasicHttpsBinding() as Binding : new BasicHttpBinding();
            var factory = new ChannelFactory<IReportingService2010>(binding);

            return factory.CreateChannel(endpoint);
        }
    }
}
