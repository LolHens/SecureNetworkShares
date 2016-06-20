using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokanNet;

namespace senes.filesystem
{
    class MountedFileSystem<F> where F : File<F>, new()
    {
        private readonly FileSystem<F> _fileSystem;
        private readonly string _mountPoint;

        private MountedFileSystem(FileSystem<F> fileSystem, string mountPoint)
        {
            this._fileSystem = fileSystem;
            this._mountPoint = mountPoint;
        }

        internal static MountedFileSystem<F> Mount(FileSystem<F> fileSystem, string mountPoint, DokanOptions mountOptions)
        {
            fileSystem.FileSystemOperations().Mount(mountPoint, mountOptions);
            return new MountedFileSystem<F>(fileSystem, mountPoint);
        }

        public void Unmount()
        {
            Dokan.RemoveMountPoint(_mountPoint);
        }

        public FileSystem<F> FileSystem()
        {
            return _fileSystem;
        }
    }
}
