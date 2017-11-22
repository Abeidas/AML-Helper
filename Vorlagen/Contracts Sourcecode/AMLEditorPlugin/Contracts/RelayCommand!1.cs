namespace AMLEditorPlugin.Contracts
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class RelayCommand<T> : ICommand
    {
        protected Predicate<T> _canExecute;
        protected Action<T> _execute;
        private int identifier;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand()
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if (this._canExecute != null)
            {
                return this._canExecute((T) parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            this._execute((T) parameter);
        }

        public int Identifier
        {
            get => 
                this.identifier
            set
            {
                this.identifier = value;
            }
        }
    }
}

