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

namespace CrushFS {
	class CrushDirectory : CrushFSO {

		private List<CrushFSO> children = new List<CrushFSO>();

		public List<CrushFSO> Children {
			get { return children; }
		}

		public CrushDirectory(string InitialName) : base(InitialName) {

		}

		public bool AddChild(CrushFSO NewChildFSO) {
			// Will need to do checks for duplicate filenames.
			children.Add(NewChildFSO);
			return true;
		}

	}
}
