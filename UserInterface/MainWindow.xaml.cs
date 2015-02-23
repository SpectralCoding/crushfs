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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Dokan;
using CrushFS;

namespace UserInterface {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			DokanOptions Options = new DokanOptions();
			Options.MountPoint = @"T:\";
			Options.DebugMode = true;
			Options.UseStdErr = true;
			Options.VolumeLabel = "CrushFS";
			int Status = DokanNet.DokanMain(Options, new CFS());
			switch (Status) {
				case DokanNet.DOKAN_DRIVE_LETTER_ERROR:
					Debug.WriteLine("Drvie letter error");
					break;
				case DokanNet.DOKAN_DRIVER_INSTALL_ERROR:
					Debug.WriteLine("Driver install error");
					break;
				case DokanNet.DOKAN_MOUNT_ERROR:
					Debug.WriteLine("Mount error");
					break;
				case DokanNet.DOKAN_START_ERROR:
					Debug.WriteLine("Start error");
					break;
				case DokanNet.DOKAN_ERROR:
					Debug.WriteLine("Unknown error");
					break;
				case DokanNet.DOKAN_SUCCESS:
					Debug.WriteLine("Success");
					break;
				default:
					Debug.WriteLine("Unknown status: %d", Status);
					break;
			}
		}
	}
}
