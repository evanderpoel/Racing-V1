using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadLapTime : MonoBehaviour
{
    public int minutes;
    public int seconds;
    public float milliseconds;
    public TMP_Text minuteDisplay;
    public TMP_Text secondDisplay;
    public TMP_Text msDisplay;
    
    void Start()
    {
        minutes = PlayerPrefs.GetInt("MinSave");
        seconds = PlayerPrefs.GetInt("SecSave");
        milliseconds = PlayerPrefs.GetFloat("msSave");
        secondDisplay.text = seconds >= 10 ? seconds.ToString() + "." : "0" + 
            seconds.ToString() + ".";
        minuteDisplay.text = minutes >= 10 ? minutes.ToString() + "." : "0" + 
            minutes.ToString() + ".";

        msDisplay.text = milliseconds.ToString("F0");
    }

}
