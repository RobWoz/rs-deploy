using CommandLine;
using CommandLine.Text;

namespace Rs.Commands
{
    public class Options
    {
        [VerbOption(VerbNames.UploadFile, HelpText = "Uploads a file to the report server.")]
        public UploadFileSubOptions UploadFileVerb { get; set; }

        [VerbOption(VerbNames.UploadFolder, HelpText = "Uploads a folder to the report server.")]
        public UploadFolderSubOptions UploadFolderVerb { get; set; }

        [VerbOption(VerbNames.CreateDatasources, HelpText = "Creates data sources on the report server from a config file containing connection strings.")]
        public CreateDatasourcesSubOptions CreateDatasourcesVerb { get; set; }

        [HelpVerbOption]
        public string DoHelpForVerb(string verbName)
        {
            return HelpText.AutoBuild(this, verbName);
        }
    }
}
