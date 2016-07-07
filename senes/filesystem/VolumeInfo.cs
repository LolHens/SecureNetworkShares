using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanNet;

namespace senes.filesystem
{
    class VolumeInfo
    {
        public string VolumeLabel { get; }
        public FileSystemFeatures Features { get; }
        public string FileSystemName { get; }

        public VolumeInfo(
            string volumeLabel,
            FileSystemFeatures features,
            string fileSystemName)
        {
            this.VolumeLabel = volumeLabel;
            this.Features = features;
            this.FileSystemName = fileSystemName;
        }
    }
}
