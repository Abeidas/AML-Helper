namespace AMLEditorPlugin.Base
{
    using AMLEditorPlugin.Contracts;
    using CAEX_ClassModel;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class PluginBase : IAMLEditorPlugin
    {
        private string _displayName;
        protected List<PluginCommand> commands;

        public event EventHandler PluginActivated;

        public event EventHandler PluginTerminated;

        public PluginBase()
        {
            PluginCommand command = new PluginCommand {
                Command = new RelayCommand<object>(new Action<object>(this.ActivateCommandExecute), new Predicate<object>(this.ActivateCommandCanExecute)),
                CommandName = "Activate",
                CommandToolTip = "Activation of the Plugin"
            };
            this.ActivatePlugin = command;
            PluginCommand command2 = new PluginCommand {
                Command = new RelayCommand<object>(new Action<object>(this.TerminateCommandExecute), new Predicate<object>(this.TerminateCommandCanExecute)),
                CommandName = "Terminate",
                CommandToolTip = "Termination of the Plugin"
            };
            this.TerminatePlugin = command2;
            this.Commands.Add(this.ActivatePlugin);
            this.Commands.Add(this.TerminatePlugin);
        }

        protected virtual bool ActivateCommandCanExecute(object parameter) => 
            !this.IsActive

        protected virtual void ActivateCommandExecute(object parameter)
        {
            this.IsActive = true;
            if (this.PluginActivated != null)
            {
                this.PluginActivated(this, EventArgs.Empty);
            }
        }

        public abstract void ChangeAMLFilePath(string amlFilePath);
        public abstract void ChangeSelectedObject(CAEXBasicObject selectedObject);
        public virtual void ExecuteCommand(PluginCommandsEnum command, string amlFilePath)
        {
            switch (command)
            {
                case PluginCommandsEnum.Activate:
                    if (!this.ActivatePlugin.Command.CanExecute(amlFilePath))
                    {
                        break;
                    }
                    this.ActivatePlugin.Command.Execute(amlFilePath);
                    return;

                case PluginCommandsEnum.Terminate:
                    if (this.TerminatePlugin.Command.CanExecute(amlFilePath))
                    {
                        this.TerminatePlugin.Command.Execute(amlFilePath);
                    }
                    break;

                default:
                    return;
            }
        }

        public abstract void PublishAutomationMLFileAndObject(string amlFilePath, CAEXBasicObject selectedObject);
        protected void RaisePluginActivated()
        {
            if (this.PluginActivated != null)
            {
                this.PluginActivated(this, EventArgs.Empty);
            }
        }

        protected void RaisePluginTerminated()
        {
            if (this.PluginTerminated != null)
            {
                this.PluginTerminated(this, EventArgs.Empty);
            }
        }

        protected virtual bool TerminateCommandCanExecute(object parameter) => 
            this.IsActive

        protected virtual void TerminateCommandExecute(object parameter)
        {
            this.IsActive = false;
            if (this.PluginTerminated != null)
            {
                this.PluginTerminated(this, EventArgs.Empty);
            }
        }

        public PluginCommand ActivatePlugin { get; private set; }

        public List<PluginCommand> Commands =>
            (this.commands ?? (this.commands = new List<PluginCommand>()))

        public virtual string DisplayName
        {
            get => 
                this._displayName
            protected set
            {
                this._displayName = value;
                this.ActivatePlugin.CommandToolTip = $"Activation of {this._displayName}";
                this.TerminatePlugin.CommandToolTip = $"Termination of {this._displayName}";
            }
        }

        public bool IsActive { get; protected set; }

        public abstract bool IsReactive { get; }

        public abstract bool IsReadonly { get; }

        public PluginCommand TerminatePlugin { get; private set; }
    }
}

