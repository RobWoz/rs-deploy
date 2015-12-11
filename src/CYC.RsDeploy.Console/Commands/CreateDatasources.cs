using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public class CreateDatasourcesSubOptions
    {
        [Option('f', "config", Required = true, HelpText = "The config file containing connection strings to create as data sources")]
        public string ConfigFile { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolder { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }
    }
}
