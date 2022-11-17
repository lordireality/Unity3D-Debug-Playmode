using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DebugConsole : MonoBehaviour
{
    private string output;
    private string stack;
    public Text consoleOutputUI;
    public GameObject consoleUIObj;

    private void Start()
    {
        CheckForDebugFile();
    }
    void CheckForDebugFile()
    {
        if (!Directory.Exists(@"game-data")) { Directory.CreateDirectory(@"game-data"); }
        if (!File.Exists(@"game-data/debugLog.dgt")) { File.Create(@"game-data/debugLog.dgt"); }
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (!consoleUIObj.activeSelf) { consoleUIObj.SetActive(true); } else
            if (consoleUIObj.activeSelf) { consoleUIObj.SetActive(false); }
        }

        Application.RegisterLogCallback(HandleLog);
    }

    private void OnEnable()
    {
        Application.RegisterLogCallback(HandleLog);
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        output = type + ": " + logString + "\n" + output;
        File.AppendAllText(@"game-data/debugLog.dgt", type + ": " + logString + "\n");
        stack += stackTrace;
        consoleOutputUI.text = output;
    }
}
