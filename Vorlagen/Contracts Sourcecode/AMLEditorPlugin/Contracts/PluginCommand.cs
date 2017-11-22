namespace AMLEditorPlugin.Contracts
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;

    public class PluginCommand : INotifyPropertyChanged
    {
        private ICommand _command;
        private string _commandName;
        private string _commandToolTip;
        private RelayCommand<object> _doNothing;
        private bool _isCheckable;
        private bool _isChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        public PluginCommand()
        {
            this.CommandToolTip = "This is a Plugin Command";
            this.CommandName = "Command";
            this.Command = this.DoNothing;
            this.IsCheckable = false;
        }

        private bool DoNothingCanExecute(object parameter) => 
            true

        private void DoNothingExecute(object parameter)
        {
            MessageBox.Show("This Command is not implemented!");
        }

        private void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public ICommand Command
        {
            get => 
                this._command
            set
            {
                if (this._command != value)
                {
                    this._command = value;
                    this.OnPropertyChanged("Command");
                }
            }
        }

        public string CommandName
        {
            get => 
                this._commandName
            set
            {
                if (this._commandName != value)
                {
                    this._commandName = value;
                    this.OnPropertyChanged("CommandName");
                }
            }
        }

        public string CommandToolTip
        {
            get => 
                this._commandToolTip
            set
            {
                if (this._commandToolTip != value)
                {
                    this._commandToolTip = value;
                    this.OnPropertyChanged("CommandToolTip");
                }
            }
        }

        private ICommand DoNothing =>
            (this._doNothing ?? (this._doNothing = new RelayCommand<object>(new Action<object>(this.DoNothingExecute), new Predicate<object>(this.DoNothingCanExecute))))

        public bool IsCheckable
        {
            get => 
                this._isCheckable
            set
            {
                if (this._isCheckable != value)
                {
                    this._isCheckable = value;
                    this.OnPropertyChanged("IsCheckable");
                }
            }
        }

        public bool IsChecked
        {
            get => 
                this._isChecked
            set
            {
                if (this._isChecked != value)
                {
                    this._isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
        }
    }
}

