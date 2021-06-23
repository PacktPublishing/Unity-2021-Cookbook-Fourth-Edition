using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;

public class InvokeRenamer
{
    [MenuItem("My Python/Underscore Renamer")]
    static void RunEnsureNaming()
    {
        PythonRunner.RunFile($"{Application.dataPath}/_Scripts/renamer.py");
    }
}
