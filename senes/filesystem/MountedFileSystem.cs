using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanNet;

namespace senes.filesystem
{
    class MountedFileSystem
    {
        private readonly FileSystem _fileSystem;
        private readonly string _mountPoint;

        private MountedFileSystem(FileSystem fileSystem, string mountPoint)
        {
            this._fileSystem = fileSystem;
            this._mountPoint = mountPoint;
        }

        internal static MountedFileSystem Mount(FileSystem fileSystem, string mountPoint)
        {
            fileSystem.Mount(mountPoint);
            return new MountedFileSystem(fileSystem, mountPoint);
        }

        public void Unmount()
        {
            Dokan.RemoveMountPoint(_mountPoint);
        }

        public FileSystem FileSystem()
        {
            return _fileSystem;
        }
    }
}
