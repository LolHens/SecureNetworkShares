using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DokanNet;
using senes.filesystem;
using FileAccess = DokanNet.FileAccess;

namespace senes
{
    class SenesFile : File<SenesFile>
    {
        public override NtStatus Create(string fileName, FileAccess access, FileShare share, bool overwrite,
            FileOptions options,
            FileAttributes attributes, DokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public override NtStatus Open(string fileName, FileAccess access, FileShare share, bool create, bool append,
            FileOptions options,
            FileAttributes attributes, DokanFileInfo fileInfo)
        {
            return DokanResult.Success;
        }

        public override NtStatus Read(string fileName, byte[] buffer, out int bytesRead, long offset, DokanFileInfo info)
        {
            bytesRead = 0;
            return DokanResult.NotImplemented;
        }

        public override NtStatus Write(string fileName, byte[] buffer, out int bytesWritten, long offset,
            DokanFileInfo info)
        {
            bytesWritten = 0;
            return DokanResult.NotImplemented;
        }

        public override NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, DokanFileInfo info)
        {
            fileInfo = new FileInformation
            {
                FileName = "test",
                Attributes = FileAttributes.Normal,
                LastAccessTime = DateTime.Now,
                LastWriteTime = DateTime.Now,
                CreationTime = DateTime.Now
            };
            return DokanResult.Success;
        }

        public override NtStatus SetAttributes(string fileName, FileAttributes attributes, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus Move(string oldName, string newName, bool replace, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus GetSecurity(string fileName, out FileSystemSecurity security,
            AccessControlSections sections,
            DokanFileInfo info)
        {
            security = null;
            return DokanResult.NotImplemented;
        }

        public override NtStatus SetSecurity(string fileName, FileSystemSecurity security,
            AccessControlSections sections, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus SetTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime,
            DateTime? lastWriteTime,
            DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override NtStatus Delete(string fileName, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public override void Close(string fileName, DokanFileInfo info)
        {
        }
    }
}
