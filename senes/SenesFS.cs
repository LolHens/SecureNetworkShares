using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DokanNet;
using senes.filesystem;

namespace senes
{
    class SenesFS : FileSystem<SenesFile>
    {
        public override NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features,
            out string fileSystemName,
            DokanFileInfo info)
        {
            volumeLabel = "Test";
            features = FileSystemFeatures.None;
            fileSystemName = string.Empty;
            return DokanResult.Success;
        }

        public override NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes,
            out long totalNumberOfFreeBytes,
            DokanFileInfo info)
        {
            freeBytesAvailable = 0;
            totalNumberOfBytes = 0;
            totalNumberOfFreeBytes = 0;
            return DokanResult.NotImplemented;
        }

        public override NtStatus FindFiles(string fileName, string searchPattern, out IList<FileInformation> files,
            DokanFileInfo info)
        {
            var fileInfo = new FileInformation
            {
                FileName = "test",
                Attributes = FileAttributes.Normal,
                LastAccessTime = DateTime.Now,
                LastWriteTime = DateTime.Now,
                CreationTime = DateTime.Now
            };

            files = new List<FileInformation> {fileInfo};

            return DokanResult.Success;
        }
    }
}
