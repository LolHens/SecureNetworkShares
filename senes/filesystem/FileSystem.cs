using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DokanNet;
using FileAccess = DokanNet.FileAccess;

namespace senes.filesystem
{
    abstract class FileSystem
    {
        private readonly FileSystemOperations _fileSystemOperations;


        public FileSystem()
        {
            _fileSystemOperations = new FileSystemOperations(this);
        }

        internal FileSystemOperations FileSystemOperations()
        {
            return _fileSystemOperations;
        }

        public MountedFileSystem Mount(string mountPoint)
        {
            return MountedFileSystem.Mount(this, mountPoint);
        }


        public abstract NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features,
            out string fileSystemName,
            DokanFileInfo info);

        public abstract NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes,
            out long totalNumberOfFreeBytes,
            DokanFileInfo info);

        public abstract NtStatus Mounted(DokanFileInfo info);

        public abstract NtStatus Unmounted(DokanFileInfo info);




        


        public abstract NtStatus CreateFile(string fileName, FileAccess access, FileShare share, bool overwrite,
            FileOptions options, FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus OpenFile(string fileName, FileAccess access, FileShare share, bool create, bool append,
            FileOptions options, FileAttributes attributes, DokanFileInfo fileInfo);

        public virtual NtStatus TruncateFile(string fileName, FileAccess access, FileShare share, FileOptions options,
            FileAttributes attributes, DokanFileInfo fileInfo)
        {
            return DokanResult.NotImplemented;
        }

        public abstract NtStatus OpenDirectory(string fileName, FileAccess access, FileShare share,
            FileOptions options,
            FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus CreateDirectory(string fileName, FileAccess access, FileShare share,
            FileOptions options,
            FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset,
            DokanFileInfo info);

        public abstract NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset,
            DokanFileInfo info);

        

        public abstract NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, DokanFileInfo info);

        public abstract NtStatus FindFiles(string fileName, string searchPattern, out IList<FileInformation> files,
            DokanFileInfo info);

        public abstract NtStatus SetFileAttributes(string fileName, FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus MoveFile(string oldName, string newName, bool replace, DokanFileInfo info);

        public abstract NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info);

        public abstract NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info);

        public abstract NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security,
            AccessControlSections sections,
            DokanFileInfo info);

        public abstract NtStatus SetFileSecurity(string fileName, FileSystemSecurity security,
            AccessControlSections sections,
            DokanFileInfo info);

        public abstract NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime,
            DateTime? lastWriteTime, DokanFileInfo info);

        public abstract NtStatus DeleteFile(string fileName, DokanFileInfo info);

        public abstract NtStatus DeleteDirectory(string fileName, DokanFileInfo info);

        public virtual NtStatus FlushFileBuffers(string fileName, DokanFileInfo info)
        {
            try
            {
                ((FileStream))
                return DokanResult.Success;
            }
            catch (IOException)
            {
                return DokanResult.DiskFull;
            }
        }

        public abstract void CloseFile(string fileName, DokanFileInfo info);


        public virtual NtStatus FindStreams(string fileName, out IList<FileInformation> streams, DokanFileInfo info)
        {
            streams = new List<FileInformation>();
            return DokanResult.NotImplemented;
        }
    }
}
