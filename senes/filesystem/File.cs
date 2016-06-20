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
    abstract class File<F> where F : File<F>, new()
    {
        internal FileSystem<F> fileSytem;
        internal bool directory;

        public abstract NtStatus Create(string fileName, FileAccess access, FileShare share, bool overwrite,
            FileOptions options, FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus Open(string fileName, FileAccess access, FileShare share, bool create, bool append,
            FileOptions options, FileAttributes attributes, DokanFileInfo fileInfo);

        public virtual NtStatus Truncate(string fileName, FileAccess access, FileShare share, FileOptions options,
            FileAttributes attributes, DokanFileInfo fileInfo)
        {
            return DokanResult.NotImplemented;
        }

        public abstract NtStatus Read(string fileName, byte[] buffer, out int bytesRead, long offset,
            DokanFileInfo info);

        public abstract NtStatus Write(string fileName, byte[] buffer, out int bytesWritten, long offset,
            DokanFileInfo info);

        public abstract NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, DokanFileInfo info);

        public abstract NtStatus SetAttributes(string fileName, FileAttributes attributes, DokanFileInfo info);

        public abstract NtStatus Move(string oldName, string newName, bool replace, DokanFileInfo info);

        public abstract NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info);

        public abstract NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info);

        public abstract NtStatus GetSecurity(string fileName, out FileSystemSecurity security,
            AccessControlSections sections,
            DokanFileInfo info);

        public abstract NtStatus SetSecurity(string fileName, FileSystemSecurity security,
            AccessControlSections sections,
            DokanFileInfo info);

        public abstract NtStatus SetTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime,
            DateTime? lastWriteTime, DokanFileInfo info);

        public abstract NtStatus Delete(string fileName, DokanFileInfo info);

        public virtual NtStatus FlushBuffers(string fileName, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public abstract void Close(string fileName, DokanFileInfo info);
    }
}