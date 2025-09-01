using System;
using System.Globalization;
using System.Windows.Input;
using IDE.Extensibility.ContextMenu.ContextMenuItems;
using IDE.Extensibility.ContextMenu.ProjectExplorer;
using VisiWin7.PlugInManager.Shared;
using VisiWinNET.Development.Services;

namespace CustomNamespace.ExtensionSample.CustomCommands
{
    /// <summary>
    /// Command that changes the name of the command.
    /// </summary>
    public class CommandChangeCommandText : ContextMenuCommand
    {
        public static string CommandText { get; set; } = "After execution, this name should be changed";

        public CommandChangeCommandText()
        {
            this.Text = CommandText;
            this.Command = new ActionCommand(this.Execute, this.CanExecute);
            this.KeyGesture = new KeyGesture(Key.C, ModifierKeys.Alt);
            this.KeyGestureText = this.KeyGesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture);
        }

        public bool CanExecute(object param)
        {
            return true;
        }

        public void Execute(object param)
        {
            try
            {
                if (param is ProjectExplorerViewNode)
                {
                    OutputLoggerService.Instance.LogEntryToOutput($"Old text='{CommandText}'");
                    CommandText = "The text is now changed";
                    this.Text = CommandText;
                    OutputLoggerService.Instance.LogEntryToOutput($"Old text='{CommandText}'");
                }
            }
            catch (Exception ex)
            {
                OutputLoggerService.Instance.LogEntryToOutput("Error occured in function 'VisiWin7.IDE.ExtensionSample.CustomCommands.Execute(object param)'");
                OutputLoggerService.Instance.LogEntryToOutput(ex, LoggingSeverity.Error);
            }
        }
    }
}