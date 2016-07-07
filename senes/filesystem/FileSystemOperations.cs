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
    class FileSystemOperations<F> : IDokanOperations where F : File<F>, new()
    {
        private readonly FileSystem<F> _fileSystem;

        public FileSystemOperations(FileSystem<F> fileSystem)
        {
            this._fileSystem = fileSystem;
        }

        public NtStatus CreateFile(string fileName, FileAccess access, FileShare share, FileMode mode,
            FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            NtStatus result;

            if (info.IsDirectory)
            {
                switch (mode)
                {
                    case FileMode.Open:
                        result = _fileSystem.OpenDirectory(fileName, access, share, options, attributes, info);
                        break;

                    case FileMode.CreateNew:
                        result = _fileSystem.CreateDirectory(fileName, access, share, options, attributes, info);
                        break;

                    default:
                        result = DokanResult.NotImplemented;
                        break;
                }
            }
            else
            {
                switch (mode)
                {
                    case FileMode.Append:
                        result = _fileSystem.OpenFile(fileName, access, share, true, true, options, attributes, info);
                        break;

                    case FileMode.Create:
                        result = _fileSystem.CreateFile(fileName, access, share, true, options, attributes, info);
                        break;

                    case FileMode.CreateNew:
                        result = _fileSystem.CreateFile(fileName, access, share, false, options, attributes, info);
                        break;

                    case FileMode.Open:
                        result = _fileSystem.OpenFile(fileName, access, share, false, false, options, attributes, info);
                        break;

                    case FileMode.OpenOrCreate:
                        result = _fileSystem.OpenFile(fileName, access, share, true, false, options, attributes, info);
                        break;

                    case FileMode.Truncate:
                        result = _fileSystem.TruncateFile(fileName, access, share, options, attributes, info);
                        break;

                    default:
                        result = DokanResult.NotImplemented;
                        break;
                }
            }

            if (result == DokanResult.Success && info.Context == null)
                info.Context = new object();

            return result;
        }

        public void Cleanup(string fileName, DokanFileInfo info)
        {
            _fileSystem.CloseFile(fileName, info);

            (info.Context as FileStream)?.Dispose();
            info.Context = null;
        }

        public void CloseFile(string fileName, DokanFileInfo info)
        {
        }

        public NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset, DokanFileInfo info)
        {
            var result = _fileSystem.ReadFile(fileName, buffer, offset, info);

            bytesRead = result.Item2;

            return result.Item1;
        }

        public NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset, DokanFileInfo info)
        {
            var result = _fileSystem.WriteFile(fileName, buffer, offset, info);

            bytesWritten = result.Item2;

            return result.Item1;
        }

        public NtStatus FlushFileBuffers(string fileName, DokanFileInfo info)
        {
            return _fileSystem.FlushFileBuffers(fileName, info);
        }

        public NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, DokanFileInfo info)
        {
            var result = _fileSystem.GetFileInformation(fileName, info);

            fileInfo = result.Item2;

            return result.Item1;
        }

        public NtStatus FindFiles(string fileName, out IList<FileInformation> files, DokanFileInfo info)
        {
            files = new List<FileInformation>();
            return DokanResult.NotImplemented;
        }

        public NtStatus FindFilesWithPattern(string fileName, string searchPattern, out IList<FileInformation> files,
            DokanFileInfo info)
        {
            var result = _fileSystem.FindFiles(fileName, searchPattern, info);

            files = result.Item2;

            return result.Item1;
        }

        public NtStatus SetFileAttributes(string fileName, FileAttributes attributes, DokanFileInfo info)
        {
            return _fileSystem.SetFileAttributes(fileName, attributes, info);
        }

        public NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime,
            DateTime? lastWriteTime,
            DokanFileInfo info)
        {
            return _fileSystem.SetFileTime(fileName, creationTime, lastAccessTime, lastWriteTime, info);
        }

        public NtStatus DeleteFile(string fileName, DokanFileInfo info)
        {
            return _fileSystem.DeleteFile(fileName, info);
        }

        public NtStatus DeleteDirectory(string fileName, DokanFileInfo info)
        {
            return _fileSystem.DeleteDirectory(fileName, info);
        }

        public NtStatus MoveFile(string oldName, string newName, bool replace, DokanFileInfo info)
        {
            return _fileSystem.MoveFile(oldName, newName, replace, info);
        }

        public NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info)
        {
            return _fileSystem.SetEndOfFile(fileName, length, info);
        }

        public NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info)
        {
            return _fileSystem.SetAllocationSize(fileName, length, info);
        }

        public NtStatus LockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public NtStatus UnlockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            return DokanResult.NotImplemented;
        }

        public NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes,
            out long totalNumberOfFreeBytes,
            DokanFileInfo info)
        {
            var result = _fileSystem.GetDiskFreeSpace(info);

            freeBytesAvailable = result.Item2.FreeBytesAvailable;
            totalNumberOfBytes = result.Item2.TotalNumberOfBytes;
            totalNumberOfFreeBytes = result.Item2.TotalNumberOfFreeBytes;

            return result.Item1;
        }

        public NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features,
            out string fileSystemName,
            DokanFileInfo info)
        {
            var result = _fileSystem.GetVolumeInformation(info);

            volumeLabel = result.Item2.VolumeLabel;
            features = result.Item2.Features;
            fileSystemName = result.Item2.FileSystemName;

            return result.Item1;
        }

        public NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security, AccessControlSections sections,
            DokanFileInfo info)
        {
            var result = _fileSystem.GetFileSecurity(fileName, sections, info);

            security = result.Item2;

            return result.Item1;
        }

        public NtStatus SetFileSecurity(string fileName, FileSystemSecurity security, AccessControlSections sections,
            DokanFileInfo info)
        {
            return _fileSystem.SetFileSecurity(fileName, security, sections, info);
        }

        public NtStatus Mounted(DokanFileInfo info)
        {
            return _fileSystem.Mounted(info);
        }

        public NtStatus Unmounted(DokanFileInfo info)
        {
            return _fileSystem.Unmounted(info);
        }

        public NtStatus FindStreams(string fileName, out IList<FileInformation> streams, DokanFileInfo info)
        {
            var result = _fileSystem.FindStreams(fileName, info);

            streams = result.Item2;

            return result.Item1;
        }
    }
}
