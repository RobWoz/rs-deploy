using System.IO;
using Rs.Constants;

namespace Rs.Services
{
    public class FileService : IFileService
    {
        public byte[] GetBytes(string file)
        {
            using (var fileStream = File.OpenRead(file))
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public string GetReportingServicesItemType(string file)
        {
            string itemType = null;

            switch (Path.GetExtension(file))
            {
                case ".rdl":
                    itemType = ItemType.Report;
                    break;

                case ".rds":
                    itemType = ItemType.DataSource;
                    break;
            }

            return itemType;
        }
    }
}
