using System;
using System.Windows.Input;

namespace CustomNamespace.ExtensionSample.CustomCommands
{
    /// <summary>
    /// Sample ICommand implementation.
    /// </summary>
    public class ActionCommand : ICommand
    {
        private readonly Func<object, bool> canExecuteHandler;
        private readonly Action<object> executeHandler;

        /// <summary>
        /// Creates a new instance of type <see cref="ActionCommand" />.
        /// </summary>
        /// <param name="execute">Delegate of the calling method.</param>
        public ActionCommand(Action<object> execute)
        {
            this.executeHandler = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Creates a new instance of type <see cref="ActionCommand" />.
        /// </summary>
        /// <param name="execute">Delegate of the calling method.</param>
        /// <param name="canExecute">
        /// Encapsulates the <see cref="System.Windows.Input.ICommand.CanExecute(object)" /> method, which returns whether the command can be executed.
        /// </param>
        public ActionCommand(Action<object> execute, Func<object, bool> canExecute)
            : this(execute)
        {
            this.canExecuteHandler = canExecute;
        }

        /// <summary>
        /// Is triggered when the result of <see cref="System.Windows.Input.ICommand.CanExecute(object)" /> changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Returns whether the command can be executed.
        /// </summary>
        /// <param name="parameter">
        /// This specifies the data required for command execution. If no data is required, pass 'null' for this parameter.
        /// </param>
        /// <returns><c>true</c> if the command can be executed in the current context, otherwise <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecuteHandler == null || this.canExecuteHandler(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">
        /// This specifies the data required for command execution. If no data is required, pass 'null' for this parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.executeHandler(parameter);
        }
    }
}