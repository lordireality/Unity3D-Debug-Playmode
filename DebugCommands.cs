
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCommands : MonoBehaviour
{
    public InputField cmdPromt;

    public void SendCommand()
    {
        Debug.Log(">>" + cmdPromt.text);
        InterpritateCMD(cmdPromt.text);
        cmdPromt.text = "";
    }
    public void InterpritateCMD(string rawCommand)
    {
        rawCommand = rawCommand.ToLower();
        string[] splitCommand = rawCommand.Split(' ');
        switch (splitCommand[0])
        {
            case "help": HelpCMD(); break;
            case "time": TimeCMD(); break;
            case "setquality": SetQualityCMD(splitCommand[1]); break;
            case "showtriggers": ShowTriggersZonesCMD(splitCommand[1]); break;
            default: NotFoundCMD(); break;
        }
    }
    private void NotFoundCMD()
    {
        Debug.Log("<color=red>Console</color>|Command not found");
    }
    private void HelpCMD()
    {
        Debug.Log("<color=red>Console</color>|<color=yellow>help</color> - for all list of commands");
        Debug.Log("<color=red>Console</color>|<color=yellow>time</color> - show current PC time");
        Debug.Log("<color=red>Console</color>|<color=yellow>setquality + 1args</color> - set global graphics settings to specific level");
        Debug.Log("<color=red>Console</color>|<color=yellow>showtriggers + 1args</color> - show and hide triggers zones");
    }
    private void TimeCMD()
    {
        Debug.Log("<color=red>Console</color>|Now is: " + DateTime.Now);
    }
    private void SetQualityCMD(string arg1)
    {
        bool isNum = Int32.TryParse(arg1, out int index);
        if (isNum) { QualitySettings.SetQualityLevel(index); Debug.Log("<color=red>Console</color>|Quality level set to: " + QualitySettings.GetQualityLevel()); }
        else { Debug.Log("<color=red>Console</color>|Args must be numeric!"); }
    }
    private void ShowTriggersZonesCMD(string arg1)
    {
        if(arg1 == "true")
        {
            GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
            foreach (GameObject go in triggers)
            {
                go.GetComponent<MeshRenderer>().enabled = true;
            }
            Debug.Log("<color=red>Console</color>|Triggers zones shown");
        }
        else if (arg1 == "false")
        {
            GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
            foreach (GameObject go in triggers)
            {
                go.GetComponent<MeshRenderer>().enabled = false;
            }
            Debug.Log("<color=red>Console</color>|Triggers zones hidden");
        } else { Debug.Log("<color=red>Console</color>|Args must be bool! true/false"); }
    }
    private void ShowOtherPlayers(string arg1)
    {

    }
}
