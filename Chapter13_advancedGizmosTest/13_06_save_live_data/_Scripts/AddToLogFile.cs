using UnityEngine; 
using System.IO; 
using System;
using UnityEngine.SceneManagement;

public class AddToLogFile : MonoBehaviour
{
	private static string _fileName = "";
	private static string _folderName = "Logs";
	private static string _filePath = "(no file path yet)";

	private static void CreateNewLogFile()
	{
		_fileName = DateTime.Now.ToString("yyy_MM_dd--HH:mm:ss") + ".csv";
		_filePath = Path.Combine(Application.dataPath, _folderName);
		_filePath = Path.Combine(_filePath, _fileName);

		// Create a file to write to.
		using (StreamWriter sw = File.CreateText(_filePath)) 
		{
			sw.WriteLine(TimeStamp() + ",created");
		}	

	}

	private static string TimeStamp()
	{
		return DateTime.Now.ToString("yyyy/MM/dd") + "," + DateTime.Now.ToString("HH:mm:ss");
	}
	
	public static void LogLine(string textLine)
	{
		// the first time we try to log a line, we need to create the file
		if (!File.Exists(_filePath)) 
		{
			CreateNewLogFile();
		}

		string sceneName = SceneManager.GetActiveScene().name;
		textLine = TimeStamp() + "," + sceneName + "," + textLine;
		
		using (StreamWriter sw = File.AppendText(_filePath)) 
		{
			sw.WriteLine(textLine);
		}	
	}
	
	
	
} 