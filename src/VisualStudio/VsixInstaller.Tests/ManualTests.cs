﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Win32;

namespace MSBuilder
{
	// Ad-hoc tests for TD.NET to try out behavior.
	class VsixInstallerTests
	{
		public void Install()
		{
			var task = new InstallVsix
			{
				VisualStudioVersion = "14.0",
				VsixPath = @"[PATH_TO_VSIX]",
				RootSuffix = "Exp",
				BuildEngine = new MockBuildEngine()
			};

			Console.WriteLine("Execute: " + task.Execute());
		}

		public void Disable()
		{
			var task = new DisableVsix
			{
				VisualStudioVersion = "14.0",
				VsixId = "Merq",
				RootSuffix = "Exp",
				FailIfNotInstalled = true,
				BuildEngine = new MockBuildEngine()
			};

			Console.WriteLine("Execute: " + task.Execute());
		}

		public void Enable()
		{
			var task = new EnableVsix
			{
				VisualStudioVersion = "14.0",
				VsixId = "Merq",
				RootSuffix = "Exp",
				FailIfNotInstalled = true,
				BuildEngine = new MockBuildEngine()
			};

			Console.WriteLine("Execute: " + task.Execute());
		}


		public void Uninstall()
		{
			var task = new UninstallVsix
			{
				VisualStudioVersion = "14.0",
				VsixId = "Merq",
				RootSuffix = "Exp",
				FailIfNotInstalled = true,
				BuildEngine = new MockBuildEngine()
			};

			Console.WriteLine("Execute: " + task.Execute());
		}

		public void ListInstalled()
		{
			var task = new ListInstalledVsix
			{
				VisualStudioVersion = "14.0",
				RootSuffix = "Exp",
				FilterExpression = "Xamarin.*",
				BuildEngine = new MockBuildEngine()
			};

			Console.WriteLine("Execute: {0} ({1})", task.Execute(), task.InstalledExtensions.Length);

			foreach (var extension in task.InstalledExtensions)
			{
				Console.WriteLine("Extension {0} ({1} metadata, InstalledPerMachine={2}).", 
					extension.ItemSpec, extension.MetadataCount, extension.GetMetadata("InstalledPerMachine"));
			}
		}
	}
}
