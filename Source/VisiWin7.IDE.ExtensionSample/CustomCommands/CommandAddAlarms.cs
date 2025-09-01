using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using IDE.Extensibility.ContextMenu.ContextMenuItems;
using IDE.Extensibility.ContextMenu.ProjectExplorer;
using VisiWin.Provider;
using VisiWin7.PlugInManager.Shared;
using VisiWinNET.Development.Services;

namespace CustomNamespace.ExtensionSample.CustomCommands
{
    /// <summary>
    /// Command that adds some alarms to the project.
    /// </summary>
    public class CommandAddAlarms : ContextMenuCommand
    {
        public CommandAddAlarms()
        {
            this.Text = "Add some alarms to this project (Works only for single projects))";
            this.Command = new ActionCommand(this.Execute, this.CanExecute);
            this.KeyGesture = new KeyGesture(Key.A, ModifierKeys.Alt);
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
                if (param is ProjectExplorerViewNode projectExplorerViewNode)
                {
                    if (projectExplorerViewNode.SelectedProject != null)
                    {
                        // Be careful with the selected project.
                        // Client projects do not have an alarm system and null will be returned, resulting in NullReferenceException. 
                        // It would be better to check here for client projects or at least throw a meaningful exception if alarmSystem is null.
                        var alarmSystem = projectExplorerViewNode.SelectedProject.ProviderProject.GetSystem<IAlarmSystem>();

                        var alarmGroup = new AlarmGroup { Name = $"AlarmGroupExtern{IndexHelper.GetAlarmGroupIndex().ToString().PadLeft(3, '0')}" };
                        alarmSystem.InsertAlarmGroup("", alarmGroup);

                        var alarms = new List<Alarm>();
                        for (var n = 1; n < 100; n++)
                        {
                            alarms.Add(new Alarm { Name = $"AlarmExtern{n.ToString().PadLeft(3, '0')}" });
                        }

                        alarmSystem.InsertAlarms(alarmGroup.Name, alarms);

                        OutputLoggerService.Instance.LogEntryToOutput($"Alarmgruppe='{alarmGroup.Name}' + {alarms.Count} 'Alarme' erfolgreich hinzugefügt!");
                    }
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