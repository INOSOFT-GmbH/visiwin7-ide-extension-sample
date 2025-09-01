using IDE.Extensibility;
using VisiWin7.PlugInManager.Shared;

namespace CustomNamespace.ExtensionSample.Project
{
    public class ProjectExtension : ProjectPackageBase
    {
        public override void VisiWinProjectFileModified(global::IDE.Extensibility.Project project)
        {
            base.VisiWinProjectFileModified(project);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.VisiWinProjectFileModified), LoggingSeverity.Debug);
        }

        public override void ProjectStarted(global::IDE.Extensibility.Project project)
        {
            base.ProjectStarted(project);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.ProjectStarted), LoggingSeverity.Debug);
        }

        public override void ProjectStopped(global::IDE.Extensibility.Project project)
        {
            base.ProjectStopped(project);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.ProjectStopped), LoggingSeverity.Debug);
        }

        public override void ProjectStopping(global::IDE.Extensibility.Project project)
        {
            base.ProjectStopping(project);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.ProjectStopping), LoggingSeverity.Debug);
        }
    }
}