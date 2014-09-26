using System;
using System.IO;
using CYC.Logging.Interface;
using Rs.Commands;
using Rs.Constants;
using Rs.ReportService2010;
using Rs.Services;

namespace Rs.Verbs
{
    public class UploadFileVerb
    {
        private readonly UploadFileSubOptions options;
        private readonly IFileService fileService;
        private readonly IReportingServiceChannelFactory channelFactory;
        private readonly ILogger logger;

        public UploadFileVerb(UploadFileSubOptions options, ILogger logger)
        {
            this.options = options;
            this.fileService = new FileService();
            this.channelFactory = new ReportingServiceChannelFactory();
            this.logger = logger;
        }

        public void Process()
        {
            if (Path.GetExtension(options.File) != ".rdl")
            {
                throw new ArgumentException("Only .rdl files can be uploaded");
            }

            logger.Info("Uploading file '{0}' to folder '{1}' on report server '{2}'", options.File, options.DestinationFolder, options.Server);

            var url = String.Format("http://{0}/reportserver/ReportService2010.asmx", options.Server);
            var channel = channelFactory.Create(url);
            
            channel.CreateCatalogItem(new CreateCatalogItemRequest
            {
                Definition = fileService.GetBytes(options.File),
                Name = Path.GetFileNameWithoutExtension(options.File),
                Parent = options.DestinationFolder,
                ItemType = ItemType.Report,
                Overwrite = true
            });
        }
    }
}
