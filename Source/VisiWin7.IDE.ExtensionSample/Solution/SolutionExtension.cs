using IDE.Extensibility;
using VisiWin7.PlugInManager.Shared;

namespace CustomNamespace.ExtensionSample.Solution
{
    public class SolutionExtension : SolutionPackageBase
    {

        public override void SolutionBuildCompleted(bool successful)
        {
            base.SolutionBuildCompleted(successful);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionBuildCompleted), LoggingSeverity.Debug);
        }

        public override void SolutionBuildStarted()
        {
            base.SolutionBuildStarted();
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionBuildStarted), LoggingSeverity.Debug);
        }

        public override void SolutionClosed()
        {
            base.SolutionClosed();
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionClosed), LoggingSeverity.Debug);
        }

        public override void SolutionClosing()
        {
            base.SolutionClosing();
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionClosing), LoggingSeverity.Debug);
        }

        public override void SolutionMerged(bool successful)
        {
            base.SolutionMerged(successful);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionMerged), LoggingSeverity.Debug);
        }

        public override void SolutionMerging()
        {
            base.SolutionMerging();
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionMerging), LoggingSeverity.Debug);
        }

        public override void SolutionOpened()
        {
            base.SolutionOpened();
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionOpened), LoggingSeverity.Debug);
        }

        public override void SolutionOpening(string solutionPath, string solutionName)
        {
            base.SolutionOpening(solutionPath, solutionName);
            this.LogDebugEntryToOutput("custom override: " + nameof(this.SolutionOpening), LoggingSeverity.Debug);
        }
    }
}