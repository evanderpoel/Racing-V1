using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class CompleteLap : MonoBehaviour
{
    public GameObject finishLineTrigger;
    public GameObject halfwayTrigger;

    public TMP_Text minuteDisplay;
    public TMP_Text secondDisplay;
    public TMP_Text milleSecondDisplay;

    private void OnTriggerEnter(Collider other)
    {
        //Setting Best Lap Time
        if ((int.Parse(Regex.Replace(minuteDisplay.text, "[^0-9]", "")) * 60 + 
             int.Parse(Regex.Replace(secondDisplay.text, "[^0-9]", ""))) * 1000 + float.Parse(Regex.Replace(milleSecondDisplay.text, "[^0-9]", "")) >
            (LapTimeManager.minutes * 60 + LapTimeManager.seconds) * 1000 + LapTimeManager.milleSeconds)
        {
            secondDisplay.text = LapTimeManager.seconds >= 10 ? LapTimeManager.seconds.ToString() + "." : "0" + 
                LapTimeManager.seconds.ToString() + ".";
            minuteDisplay.text = LapTimeManager.minutes >= 10 ? LapTimeManager.minutes.ToString() + "." : "0" + 
                LapTimeManager.minutes.ToString() + ".";

            milleSecondDisplay.text = LapTimeManager.milleSeconds.ToString("F0");
        
            PlayerPrefs.SetInt("MinSave", LapTimeManager.minutes);
            PlayerPrefs.SetInt("SecSave", LapTimeManager.seconds);
            PlayerPrefs.SetFloat("msSave", LapTimeManager.milleSeconds);
        }

        LapTimeManager.minutes = 0;
        LapTimeManager.seconds = 0;
        LapTimeManager.milleSeconds = 0;
        
        //Reset Checkpoints
        finishLineTrigger.SetActive(false);
        halfwayTrigger.SetActive(true);
        
    }
}
