using CommandLine;
using CommandLine.Text;

namespace Rs.Commands
{
    public class Options
    {
        [VerbOption(VerbNames.UploadFile, HelpText = "Uploads a file to the report server and updates data source references within it.")]
        public UploadFileSubOptions UploadFileVerb { get; set; }

        [VerbOption(VerbNames.UploadFolder, HelpText = "Uploads all reports in a folder to the report server and updates data source references within them.")]
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
