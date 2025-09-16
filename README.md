<!-- Readme for open source repositories -->
# VisiWin7.IDE.ExtensionSample
This application illustrates how to use the API `VisiWin7.IDE.Extensibility` to respond to events within the VisiWin 7 IDE.
The `ProjectExtension` and `SolutionExtension` classes show how to use global events to react to them by overriding some methods from the base classes.
The `ProjectExplorerContextMenuCommandServiceExtension` shows how to modify the Project Explorer context menu.

## Prerequisites
Install VisiWin7 IDE to get the required dependencies in place.

If VisiWin7 is installed in another Path than `C:\Program Files (x86)\INOSOFT GmbH\VisiWin 7\Development\bin`, you neeed to specify the path in the `IdeInstallationDir` property in the project file.

This sample works with and was tested with VisiWin 7 2025-1 and later.

### Warning
If a DLL uses the VisiWin components and builds into the extension folder of the VisiWin7 IDE, the references must always be set to `CopyLocal = false`!
The extension folder may only contain custom and third-party DLLs.

## Details
The following section describes which parts of the VisiWin7 IDE can be extended and how to do it.

### About Dialog
To customize the first page of the About dialog, you need to create a new `Usercontrol` that inherits from the `AboutDialogUserControlBase` class. See [CustomAboutDialog.xaml](Source\VisiWin7.IDE.ExtensionSample\AboutDialog\CustomAboutDialog.xaml).

The DataContext property is of type `AboutInfo`. It is also possible to bind to the ViewModel itself.
```
namespace IDE.Extensibility.About
{
    public class AboutInfo
    {
        public string InstallerVersion { get; set; }

        /// <summary>
        /// AssemblyConfigurationAttribute, read from the entering assembly.
        /// </summary>
        public string BuildVersion { get; set; }

        /// <summary>
        /// AssemblyCopyrightAttribute, read from executing assembly.
        /// </summary>
        public string Copyright { get; set; }

        public LicenseTypes InstalledLicense { get; set; }
        public bool WinFormsLicensed { get; set; }
        public bool WpfLicensed { get; set; }
        public bool HtmlLicensed { get; set; }
    }
}
```

### Custom Commands

The class `ProjectExplorerContextMenuCommandServiceExtension` demonstrates how to extend `ProjectExplorerContextMenuCommandService` to add custom commands to the context menu of the project explorer. It is also possible to remove or modify existing commands.

 See [ProjectExplorerContextMenuCommandServiceExtension.cs](Source\VisiWin7.IDE.ExtensionSample\CustomCommands\ProjectExplorerContextMenuCommandServiceExtension.cs).

### ProjectExtension

Override of the base class `ProjectPackageBase`, which is used to interact with project events like `VisiWinProjectFileModified`.

See [ProjectExtension.cs](Source\VisiWin7.IDE.ExtensionSample\Project\ProjectExtension.cs).

### SolutionExtension

Override of the base class `SolutionPackageBase`, which is used to interact with solution events like `SolutionOpening`.

See [SolutionExtension.cs](Source\VisiWin7.IDE.ExtensionSample\Solution\SolutionExtension.cs).
