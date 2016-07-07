using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senes.filesystem
{
    class DiskSpaceInfo
    {
        public long FreeBytesAvailable { get; }
        public long TotalNumberOfBytes { get; }
        public long TotalNumberOfFreeBytes { get; }

        public DiskSpaceInfo(
            long freeBytesAvailable,
            long totalNumberOfBytes,
            long totalNumberOfFreeBytes)
        {
            this.FreeBytesAvailable = freeBytesAvailable;
            this.TotalNumberOfBytes = totalNumberOfBytes;
            this.TotalNumberOfFreeBytes = totalNumberOfFreeBytes;
        }
    }
}
