using System.IO;
using System.Linq;
using CYC.RsDeploy.Console.Commands;
using NLog;

namespace CYC.RsDeploy.Console.Verbs
{
    public class UploadFolderVerb : UploadVerbBase
    {
        private readonly UploadFolderSubOptions options;

        public UploadFolderVerb(UploadFolderSubOptions options, Logger logger) : base (logger, options.Server)
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
