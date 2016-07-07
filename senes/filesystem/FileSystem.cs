using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using DokanNet;
using FileAccess = DokanNet.FileAccess;

namespace senes.filesystem
{
    abstract class FileSystem<F> where F : File<F>, new()
    {
        private readonly FileSystemOperations<F> _fileSystemOperations;


        public FileSystem()
        {
            _fileSystemOperations = new FileSystemOperations<F>(this);
        }

        internal FileSystemOperations<F> FileSystemOperations()
        {
            return _fileSystemOperations;
        }

        public MountedFileSystem<F> Mount(string mountPoint, DokanOptions mountOptions)
        {
            return MountedFileSystem<F>.Mount(this, mountPoint, mountOptions);
        }


        public abstract Tuple<NtStatus, VolumeInfo> GetVolumeInformation(DokanFileInfo info);

        public abstract Tuple<NtStatus, DiskSpaceInfo> GetDiskFreeSpace(DokanFileInfo info);

        public virtual NtStatus Mounted(DokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public virtual NtStatus Unmounted(DokanFileInfo info)
        {
            return DokanResult.Success;
        }


        private F NewFile(bool directory)
        {
            F file = new F();

            file.fileSytem = this;
            file.directory = directory;

            return file;
        }

        public virtual NtStatus OpenFile(string fileName, FileAccess access, FileShare share, bool create, bool append,
            FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            F file = NewFile(false);

            info.Context = file;

            return file.Open(fileName, access, share, create, append, options, attributes, info);
        }

        public virtual NtStatus CreateFile(string fileName, FileAccess access, FileShare share, bool overwrite,
            FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            F file = NewFile(false);

            info.Context = file;

            return file.Create(fileName, access, share, overwrite, options, attributes, info);
        }

        public virtual NtStatus TruncateFile(string fileName, FileAccess access, FileShare share, FileOptions options,
            FileAttributes attributes, DokanFileInfo info)
        {
            F file = NewFile(false);

            info.Context = file;

            return file.Truncate(fileName, access, share, options, attributes, info);
        }

        public virtual NtStatus OpenDirectory(string fileName, FileAccess access, FileShare share,
            FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            F file = NewFile(true);

            info.Context = file;

            return file.Open(fileName, access, share, false, false, options, attributes, info);
        }

        public virtual NtStatus CreateDirectory(string fileName, FileAccess access, FileShare share,
            FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            F file = NewFile(true);

            info.Context = file;

            return file.Create(fileName, access, share, false, options, attributes, info);
        }


        public virtual Tuple<NtStatus, int> ReadFile(string fileName, byte[] buffer, long offset,
            DokanFileInfo info)
        {
            return ((F) info.Context).Read(fileName, buffer, offset, info);
        }

        public virtual Tuple<NtStatus, int> WriteFile(string fileName, byte[] buffer, long offset,
            DokanFileInfo info)
        {
            return ((F) info.Context).Write(fileName, buffer, offset, info);
        }


        public virtual Tuple<NtStatus, FileInformation> GetFileInformation(string fileName, DokanFileInfo info)
        {
            return ((F) info.Context).GetFileInformation(fileName, info);
        }

        public virtual NtStatus SetFileAttributes(string fileName, FileAttributes attributes, DokanFileInfo info)
        {
            return ((F) info.Context).SetAttributes(fileName, attributes, info);
        }

        public virtual NtStatus MoveFile(string oldName, string newName, bool replace, DokanFileInfo info)
        {
            return ((F) info.Context).Move(oldName, newName, replace, info);
        }

        public virtual NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info)
        {
            return ((F) info.Context).SetEndOfFile(fileName, length, info);
        }

        public virtual NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info)
        {
            return ((F) info.Context).SetAllocationSize(fileName, length, info);
        }

        public virtual Tuple<NtStatus, FileSystemSecurity> GetFileSecurity(string fileName, AccessControlSections sections, DokanFileInfo info)
        {
            return ((F) info.Context).GetSecurity(fileName, sections, info);
        }

        public virtual NtStatus SetFileSecurity(string fileName, FileSystemSecurity security,
            AccessControlSections sections, DokanFileInfo info)
        {
            return ((F) info.Context).SetSecurity(fileName, security, sections, info);
        }

        public virtual NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime,
            DateTime? lastWriteTime, DokanFileInfo info)
        {
            return ((F) info.Context).SetTime(fileName, creationTime, lastAccessTime, lastWriteTime, info);
        }

        public virtual NtStatus DeleteFile(string fileName, DokanFileInfo info)
        {
            return ((F) info.Context).Delete(fileName, info);
        }

        public virtual NtStatus DeleteDirectory(string fileName, DokanFileInfo info)
        {
            return ((F) info.Context).Delete(fileName, info);
        }

        public virtual NtStatus FlushFileBuffers(string fileName, DokanFileInfo info)
        {
            return ((F) info.Context).FlushBuffers(fileName, info);
        }

        public virtual void CloseFile(string fileName, DokanFileInfo info)
        {
            ((F) info.Context).Close(fileName, info);
        }


        public abstract Tuple<NtStatus, IList<FileInformation>> FindFiles(string fileName, string searchPattern, DokanFileInfo info);

        public virtual Tuple<NtStatus, IList<FileInformation>>  FindStreams(string fileName, DokanFileInfo info)
        {
            return new Tuple<NtStatus, IList<FileInformation>>(DokanResult.NotImplemented, new List<FileInformation>());
        }
    }
}
