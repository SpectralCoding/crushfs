// Copyright 2015 SpectralCoding
// 
// This file is part of CrushFS.
// 
// CrushFS is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// CrushFS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with CrushFS.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Dokan;

namespace CrushFS {
    public class CFS : DokanOperations {
		private FileManagement FileSystem;
        #region DokanOperations member

		public CFS() {
			FileSystem = new FileManagement();
        }

        public int Cleanup(string filename, DokanFileInfo info) {
            return 0;
        }

        public int CloseFile(string filename, DokanFileInfo info) {
            return 0;
        }

        public int CreateDirectory(string filename, DokanFileInfo info) {
            return -1;
        }

        public int CreateFile(string filename, FileAccess access, FileShare share, FileMode mode, FileOptions options, DokanFileInfo info) {
            return 0;
        }

        public int DeleteDirectory(string filename, DokanFileInfo info) {
            return -1;
        }

        public int DeleteFile(string filename, DokanFileInfo info) {
            return -1;
        }


        public int FlushFileBuffers(string filename, DokanFileInfo info) {
            return -1;
        }

		public int FindFiles(string FileToFind, ArrayList ReturnFiles, DokanFileInfo FileInfo) {
			return FileSystem.List(FileToFind, ReturnFiles, FileInfo);
        }


        public int GetFileInformation(string Filename, FileInformation FileInfo, DokanFileInfo Info) {
			return FileSystem.FileInformation(Filename, FileInfo, Info);
        }

        public int LockFile(string filename, long offset, long length, DokanFileInfo info) {
            return 0;
        }

        public int MoveFile(string filename, string newname, bool replace, DokanFileInfo info) {
            return -1;
        }

        public int OpenDirectory(string filename, DokanFileInfo info) {
            return 0;
        }

        public int ReadFile(string filename, byte[] buffer, ref uint readBytes, long offset, DokanFileInfo info) {
            return -1;
        }

        public int SetEndOfFile(string filename, long length, DokanFileInfo info) {
            return -1;
        }

        public int SetAllocationSize(string filename, long length, DokanFileInfo info) {
            return -1;
        }

        public int SetFileAttributes(string filename, System.IO.FileAttributes attr, DokanFileInfo info) {
            return -1;
        }

        public int SetFileTime(string filename, DateTime ctime, DateTime atime, DateTime mtime, DokanFileInfo info) {
            return -1;
        }

        public int UnlockFile(string filename, long offset, long length, DokanFileInfo info) {
            return 0;
        }

        public int Unmount(DokanFileInfo info) {
            return 0;
        }

        public int GetDiskFreeSpace(ref ulong freeBytesAvailable, ref ulong totalBytes, ref ulong totalFreeBytes, DokanFileInfo info) {
            freeBytesAvailable = 512 * 1024 * 1024;
            totalBytes = 1024 * 1024 * 1024;
            totalFreeBytes = 512 * 1024 * 1024;
            return 0;
        }

        public int WriteFile(string filename, byte[] buffer, ref uint writtenBytes, long offset, DokanFileInfo info) {
            return -1;
        }

        #endregion


    }
}
