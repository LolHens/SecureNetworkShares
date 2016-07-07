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

namespace senes.impl
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

        public override Tuple<NtStatus, int> Read(string fileName, byte[] buffer, long offset, DokanFileInfo info)
        {
            return new Tuple<NtStatus, int>(
                DokanResult.NotImplemented,
                0);
        }

        public override Tuple<NtStatus, int> Write(string fileName, byte[] buffer, long offset, DokanFileInfo info)
        {
            return new Tuple<NtStatus, int>(
                DokanResult.NotImplemented,
                0);
        }

        public override Tuple<NtStatus, FileInformation> GetFileInformation(string fileName, DokanFileInfo info)
        {
            return new Tuple<NtStatus, FileInformation>(
                DokanResult.Success,
                new FileInformation
                {
                    FileName = "test",
                    Attributes = FileAttributes.Normal,
                    LastAccessTime = DateTime.Now,
                    LastWriteTime = DateTime.Now,
                    CreationTime = DateTime.Now
                });
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

        public override Tuple<NtStatus, FileSystemSecurity> GetSecurity(string fileName, AccessControlSections sections,
            DokanFileInfo info)
        {
            return new Tuple<NtStatus, FileSystemSecurity>(
                DokanResult.NotImplemented,
                null);
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
            Console.WriteLine("Not called?");
            return DokanResult.FileNotFound;
        }

        public override void Close(string fileName, DokanFileInfo info)
        {
        }
    }
}
