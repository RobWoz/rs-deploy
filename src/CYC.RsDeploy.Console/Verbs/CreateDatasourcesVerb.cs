using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.ReportService2010;
using NLog;

namespace CYC.RsDeploy.Console.Verbs
{
    public class CreateDatasourcesVerb
    {
        private readonly CreateDatasourcesSubOptions options;
        private readonly IReportingServiceChannelFactory channelFactory;
        private readonly ILogger logger;

        private string[] blackListedConnectionStrings = { "LocalSqlServer", "OraAspNetConString" };

        public CreateDatasourcesVerb(CreateDatasourcesSubOptions options, ILogger logger)
        {
            this.options = options;
            this.channelFactory = new ReportingServiceChannelFactory();
            this.logger = logger;
        }

        public void Process()
        {
            var config = LoadConfig(options.ConfigFile);

            var url = String.Format("http://{0}/reportserver/ReportService2010.asmx", options.Server);
            var channel = channelFactory.Create(url);

            foreach (ConnectionStringSettings connectionString in config.ConnectionStrings.ConnectionStrings)
            {
                if (blackListedConnectionStrings.Contains(connectionString.Name))
                {
                    continue;
                }
                
                logger.Info("Creating datasource for connection string '{0}'", connectionString.Name);
                
                var builder = new SqlConnectionStringBuilder(connectionString.ConnectionString);

                channel.CreateDataSource(new CreateDataSourceRequest
                {
                    DataSource = connectionString.Name,
                    Definition = new DataSourceDefinition
                    {
                        ConnectString = String.Format("Data Source={0};Initial Catalog={1}", builder.DataSource, builder.InitialCatalog),
                        UserName = builder.UserID,
                        Password = builder.Password,
                        Extension = "SQL",
                        CredentialRetrieval = CredentialRetrievalEnum.Store,
                    },
                    Overwrite = true,
                    Parent = options.DestinationFolder
                });
            }
        }

        private Configuration LoadConfig(string configFile)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }
    }
}
