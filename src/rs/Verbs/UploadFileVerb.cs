using System;
using System.IO;
using Rs.Commands;
using Rs.ReportService2010;
using Rs.Services;

namespace Rs.Verbs
{
    public class UploadFileVerb
    {
        private readonly UploadFileSubOptions options;
        private readonly IFileService fileService;
        private readonly IReportingServiceChannelFactory channelFactory;

        public UploadFileVerb(UploadFileSubOptions options)
        {
            this.options = options;
            this.fileService = new FileService();
            this.channelFactory = new ReportingServiceChannelFactory();
        }

        public void Process()
        {
            var itemType = fileService.GetReportingServicesItemType(options.File);
            if (itemType == null)
            {
                throw new ArgumentException("Only .rpt or .rds files can be uploaded");
            }

            var url = String.Format("http://{0}/reportserver/ReportService2010.asmx", options.Server);
            var channel = channelFactory.Create(url);
            
            channel.CreateCatalogItem(new CreateCatalogItemRequest
            {
                Definition = fileService.GetBytes(options.File),
                Name = Path.GetFileNameWithoutExtension(options.File),
                Parent = options.DestinationFolder,
                ItemType = itemType,
                Overwrite = true
            });
        }
    }
}
