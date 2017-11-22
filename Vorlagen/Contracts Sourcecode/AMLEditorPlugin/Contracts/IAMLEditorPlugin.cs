namespace AMLEditorPlugin.Contracts
{
    using CAEX_ClassModel;
    using System;
    using System.Collections.Generic;

    public interface IAMLEditorPlugin
    {
        event EventHandler PluginActivated;

        event EventHandler PluginTerminated;

        void ChangeAMLFilePath(string amlFilePath);
        void ChangeSelectedObject(CAEXBasicObject selectedObject);
        void ExecuteCommand(PluginCommandsEnum command, string amlFilePath);
        void PublishAutomationMLFileAndObject(string amlFilePath, CAEXBasicObject selectedObject);

        PluginCommand ActivatePlugin { get; }

        List<PluginCommand> Commands { get; }

        string DisplayName { get; }

        bool IsActive { get; }

        bool IsReactive { get; }

        bool IsReadonly { get; }

        PluginCommand TerminatePlugin { get; }
    }
}

