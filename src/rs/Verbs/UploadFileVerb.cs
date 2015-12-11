using System;
using System.IO;
using NLog;
using Rs.Commands;

namespace Rs.Verbs
{
    public class UploadFileVerb : UploadVerbBase
    {
        private readonly UploadFileSubOptions options;
        
        public UploadFileVerb(UploadFileSubOptions options, Logger logger) : base(logger, options.Server)
        {
            this.options = options;
        }

        public void Process()
        {
            if (Path.GetExtension(options.File) != ".rdl")
            {
                throw new ArgumentException("Only .rdl files can be uploaded");
            }

            UploadFile(options.File, options.DestinationFolder, options.Server);
        }
    }
}
