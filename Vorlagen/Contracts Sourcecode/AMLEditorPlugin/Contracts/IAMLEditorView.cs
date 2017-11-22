namespace AMLEditorPlugin.Contracts
{
    using System;
    using System.Windows;

    public interface IAMLEditorView : IFrameworkInputElement, IInputElement, IAMLEditorPlugin
    {
        bool CanClose { get; }
    }
}

