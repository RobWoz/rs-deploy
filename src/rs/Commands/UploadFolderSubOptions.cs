using CommandLine;

namespace Rs.Commands
{
    public class UploadFolderSubOptions
    {
        [Option('f', "folder", Required = true, HelpText = "The folder containing .rdl and .rds files to be upload.")]
        public string Folder { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolder { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }
    }
}
