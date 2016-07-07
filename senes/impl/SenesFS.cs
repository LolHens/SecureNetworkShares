using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanNet;
using senes.filesystem;

namespace senes.impl
{
    class SenesFS : FileSystem<SenesFile>
    {
        public override Tuple<NtStatus, VolumeInfo> GetVolumeInformation(DokanFileInfo info)
        {
            return new Tuple<NtStatus, VolumeInfo>(
                DokanResult.Success,
                new VolumeInfo("SenesDrive", FileSystemFeatures.None, "SenesFS"));
        }

        public override Tuple<NtStatus, DiskSpaceInfo> GetDiskFreeSpace(DokanFileInfo info)
        {
            return new Tuple<NtStatus, DiskSpaceInfo>(
                DokanResult.Success,
                new DiskSpaceInfo(0, 0, 0));
        }

        public override Tuple<NtStatus, IList<FileInformation>> FindFiles(string fileName, string searchPattern,
            DokanFileInfo info)
        {
            return new Tuple<NtStatus, IList<FileInformation>>(
                DokanResult.Success,
                new List<FileInformation>
                {
                    new FileInformation
                    {
                        FileName = "test",
                        Attributes = FileAttributes.Normal,
                        LastAccessTime = DateTime.Now,
                        LastWriteTime = DateTime.Now,
                        CreationTime = DateTime.Now
                    }
                });
        }
    }
}
