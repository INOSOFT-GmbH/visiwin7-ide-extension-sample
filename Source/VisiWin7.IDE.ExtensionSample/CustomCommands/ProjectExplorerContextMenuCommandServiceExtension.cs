using System.Collections.Generic;
using System.Linq;
using IDE.Extensibility.ContextMenu.ContextMenuItems;
using IDE.Extensibility.ContextMenu.ProjectExplorer;
using VisiWinNET.Development.Services;
using VisiWinNET.PDB;

namespace CustomNamespace.ExtensionSample.CustomCommands
{
    /// <summary>
    /// This class implements the ProjectExplorerContextMenuCommandService to modify the context menu of the project explorer.
    /// </summary>
    public class ProjectExplorerContextMenuCommandServiceExtension : ProjectExplorerContextMenuCommandService
    {
        public override List<ContextMenuItem> ModifyContextMenu(ProjectExplorerContextMenuProvider contextMenuProvider, List<ContextMenuItem> contextMenuCommands)
        {
            var selectedNode = contextMenuProvider.SelectedNodes.FirstOrDefault();

            if (selectedNode != null)
            {
                OutputLoggerService.Instance.LogEntryToOutput($">>>\tNodeText='{selectedNode.NodeText}'");

                if (selectedNode?.NodeType?.DesignNodeType != DesignTypes.Unknown)
                {
                    // Add a change name command to change the name of the command itself
                    contextMenuCommands.Add(new CommandChangeCommandText());

                    OutputLoggerService.Instance.LogEntryToOutput($">>>\tDesignNodeType='{selectedNode.NodeType?.DesignNodeType.ToString()}'   -    RelativePath='{selectedNode.RelativePath}'");
                }
                else if (selectedNode?.NodeType?.ProcessDataNodeType != NodeTypes.Unknown)
                {
                    string sSystemType = selectedNode.NodeType?.ProcessDataSystemType.ToString();
                    string sNodeType = selectedNode.NodeType?.ProcessDataNodeType.ToString();

                    OutputLoggerService.Instance.LogEntryToOutput($">>>\tSystemType='{sSystemType}'   -    NodeType='{sNodeType}'" );
                }

                // Modify only for directories under the Design node
                if (selectedNode.NodeType?.DesignNodeType == DesignTypes.Directory && selectedNode.RelativePath.StartsWith($@"{selectedNode?.SelectedProject.ProjectName}\MyFiles"))
                {
                    // Clear the complete context menu
                    contextMenuCommands.Clear();

                    // Add a separator
                    contextMenuCommands.Add(new ContextMenuSeparator());

                    // Add a dummy command
                    contextMenuCommands.Add(new CommandDummy());
                }
                else if (selectedNode.NodeType?.ProcessDataSystemType == SystemTypes.Alarm && selectedNode.NodeType?.ProcessDataNodeType == NodeTypes.AlarmGroups)
                {
                    // Add a separator
                    contextMenuCommands.Insert(0, new ContextMenuSeparator());

                    // Add demo command to add some alarms
                    contextMenuCommands.Insert(0, new CommandAddAlarms());
                }
            }

            return contextMenuCommands;
        }
    }
}