using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public class UploadFileSubOptions
    {
        [Option('f', "file", Required = true, HelpText = "The file to be upload.")]
        public string File { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolder { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }
    }
}
