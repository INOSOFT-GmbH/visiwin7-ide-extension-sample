using System.Globalization;
using System.Windows.Input;
using IDE.Extensibility.ContextMenu.ContextMenuItems;

namespace CustomNamespace.ExtensionSample.CustomCommands
{
    public class CommandDummy : ContextMenuCommand
    {
        public CommandDummy()
        {
            this.Text = "This context menu item was added in the extension";
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
            // Do nothing because this is a dummy command
        }
    }
}