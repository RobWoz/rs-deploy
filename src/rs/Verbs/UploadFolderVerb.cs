using System.IO;
using System.Linq;
using CYC.Logging.Interface;
using Rs.Commands;

namespace Rs.Verbs
{
    public class UploadFolderVerb : UploadVerbBase
    {
        private readonly UploadFolderSubOptions options;

        public UploadFolderVerb(UploadFolderSubOptions options, ILogger logger) : base (logger, options.Server)
        {
            this.options = options;
        }

        public void Process()
        {
            var files = Directory.EnumerateFiles(options.Folder, "*.rdl").ToList();
            
            if (files.Any())
            {
                files.ForEach(file => UploadFile(file, options.DestinationFolder, options.Server));
            }
            else
            {
                logger.Info("No .rdl files found to upload in folder '{0}'", options.DestinationFolder);   
            }
        }
    }
}
