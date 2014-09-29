using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Rs.ReportService2010
{
    public class ReportingServiceChannelFactory : IReportingServiceChannelFactory
    {
        public IReportingService2010 Create(string url)
        {
            var endpoint = new EndpointAddress(url);
            var binding = endpoint.Uri.Scheme == "https" ? GetBasicHttpsBinding() : GetBasicHttpBinding();
            var factory = new ChannelFactory<IReportingService2010>(binding);

            factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.None;

            return factory.CreateChannel(endpoint);
        }

        private Binding GetBasicHttpBinding()
        {
            var binding = new BasicHttpBinding
            {
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = new HttpTransportSecurity
                    {
                        ClientCredentialType = HttpClientCredentialType.Ntlm,
                    }
                },

            };

            return binding;
        }

        private Binding GetBasicHttpsBinding()
        {
            var binding = new BasicHttpsBinding
            {
                Security = new BasicHttpsSecurity
                {
                    Mode = BasicHttpsSecurityMode.Transport,
                    Transport = new HttpTransportSecurity
                    {
                        ClientCredentialType = HttpClientCredentialType.Ntlm,
                    }
                },

            };

            return binding;
        }
    }
}
