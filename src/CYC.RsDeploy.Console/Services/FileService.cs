using System;
using System.IO;
using System.Linq;
using CYC.RsDeploy.Console.Constants;

namespace CYC.RsDeploy.Console.Services
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

        public string GetFileName(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            return fileName.Split('.').Last();
        }

        public string ExpandFileNamePath(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var parts = fileName.Split('.');
            string path = null;

            if (parts.Length > 1)
            {
                path = String.Join("/", parts.Reverse().Skip(1).Reverse());
            }

            return path;
        }
    }
}
