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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dokan;

namespace CrushFS {
	class CrushFSO {
		private string name;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public CrushFSO(string InitialName) {
			Name = InitialName;
		}

		public FileInformation GetFileInfo() {
			FileInformation tempFileInfo = new FileInformation();
			tempFileInfo.FileName = Name;
			if (this is CrushFile) {
				tempFileInfo.Attributes = FileAttributes.Normal;
			} else if (this is CrushDirectory) {
				tempFileInfo.Attributes = FileAttributes.Directory;
			}
			tempFileInfo.CreationTime = DateTime.Now;
			tempFileInfo.LastAccessTime = DateTime.Now;
			tempFileInfo.LastWriteTime = DateTime.Now;
			return tempFileInfo;
		}

		public FileInformation GetFileInfo(FileInformation ExistingFI) {
			ExistingFI.FileName = Name;
			if (this is CrushFile) {
				ExistingFI.Attributes = FileAttributes.Normal;
			} else if (this is CrushDirectory) {
				ExistingFI.Attributes = FileAttributes.Directory;
			}
			ExistingFI.CreationTime = DateTime.Now;
			ExistingFI.LastAccessTime = DateTime.Now;
			ExistingFI.LastWriteTime = DateTime.Now;
			return ExistingFI;
		}


	}
}
