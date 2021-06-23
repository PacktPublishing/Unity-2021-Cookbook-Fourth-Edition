using UnityEditor.Scripting.Python;
using UnityEditor;

public class HelloConsole
{
    [MenuItem("My Python/Hello Console")]
    static void PrintHelloWorldFromPython()
    {
        PythonRunner.RunString(@"
                import UnityEngine;
                UnityEngine.Debug.Log('hello console')
                ");
    }
}