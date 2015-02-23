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
	public class FileManagement {

		private CrushDirectory RootFSO = new CrushDirectory(@"\");

		public FileManagement() {
			RootFSO.AddChild(new CrushFile("TestFile1.txt"));
			RootFSO.AddChild(new CrushFile("TestFile2.txt"));
			RootFSO.AddChild(new CrushFile("TestFile3.txt"));
			RootFSO.AddChild(new CrushDirectory("Dir1"));
			RootFSO.AddChild(new CrushDirectory("Dir2"));
			RootFSO.AddChild(new CrushDirectory("Dir3"));
			((CrushDirectory)RootFSO.Children[3]).AddChild(new CrushFile("Internal1.txt"));
			((CrushDirectory)RootFSO.Children[3]).AddChild(new CrushFile("Internal2.txt"));
			((CrushDirectory)RootFSO.Children[3]).AddChild(new CrushFile("Internal3.txt"));
		}

		public int List(string FileToFind, ArrayList ReturnFiles, DokanFileInfo FileInfo) {
			CrushDirectory DirectoryFSO = (CrushDirectory)FindObject(FileToFind, RootFSO);
			foreach (CrushFSO CurFSO in DirectoryFSO.Children) {
				// Create a new FileInfo object and add it to the list of return files.
				ReturnFiles.Add(CurFSO.GetFileInfo());
			}
			return 0;
		}

		public int FileInformation(string Filename, FileInformation FileInfo, DokanFileInfo Info) {
			Console.WriteLine("Get File Info: " + Filename);
			CrushFSO TempFSO = FindObject(Filename, RootFSO);
			if (TempFSO == null) {
				return -1;
			} else {
				// Update the file information object we were passed from Dokan, don't create a new one.
				FindObject(Filename, RootFSO).GetFileInfo(FileInfo);
				return 0;
			}
		}

		private CrushFSO FindObject(string Path, CrushFSO BaseFSO) {
			Console.WriteLine("Path: " + Path + " | BaseFSO: " + BaseFSO.Name);
			if (BaseFSO is CrushFile) {
				// We were searching for a file and found it.
				return BaseFSO;
			} else {
				if (Path == String.Empty) {
					// We were searching for a directory and found it.
					return BaseFSO;
				} else if (Path == @"\") {
					// It actually wants the root FSO.
					return RootFSO;
				} else {
					// We need to go deeper to find the file.
					if (Path.Substring(0, 1) == @"\") { Path = Path.Substring(1); }
					string NextLevel;
					string CurrentLevel;
					int NextSlash = Path.IndexOf(@"\");
					if (NextSlash > 0) {
						// We're not to the lowest level yet so chop off current directory.
						// Dir1/Dir2/File.txt => Dir2/File.txt
						NextLevel = Path.Substring(NextSlash + 1);
						CurrentLevel = Path.Substring(0, NextSlash);
					} else {
						// We're at the lowest level. Next iteration should return immediately.
						NextLevel = String.Empty;
						CurrentLevel = Path;
					}
					CrushDirectory BaseDir = (CrushDirectory)BaseFSO;
					foreach (CrushFSO CurFSO in BaseDir.Children) {
						if (CurFSO.Name == CurrentLevel) {
							// If we found either the end file/dir or the correct next level, call this function again recursively.
							// If CurFSO is the correct file or directory we're looking for then NextLevel should be blank and it
							// will return immediately. Not sure about overhead of calling this function again needlessly. A 
							// potential optimization could be to add an if statement that will check for an empty NextLevel and
							// return the CurFSO as-is.
							return FindObject(NextLevel, CurFSO);
						}
					}
				}
			}
			return null;
		}

	}
}
