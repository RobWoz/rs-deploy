using CommandLine;
using CommandLine.Text;

namespace Rs.Commands
{
    public class Options
    {
        [VerbOption(VerbNames.UploadFile, HelpText = "Uploads a file to the report server.")]
        public UploadFileSubOptions UploadFileVerb { get; set; }

        [HelpVerbOption]
        public string DoHelpForVerb(string verbName)
        {
            return HelpText.AutoBuild(this, verbName);
        }
    }
}
