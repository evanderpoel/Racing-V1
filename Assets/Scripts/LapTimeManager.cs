using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapTimeManager : MonoBehaviour
{
    public static int minutes;
    public static int seconds;
    public static float milleSeconds;

    public TMP_Text MinuteBox;
    public TMP_Text SecondBox;
    public TMP_Text MilleBox;
    
    void Update()
    {
        milleSeconds += Time.deltaTime * 10;
        
        if (milleSeconds > 9)
        {
            milleSeconds = 0;
            seconds += 1;
        }

        if (seconds >= 60)
        {
            seconds = 0;
            minutes += 1;
        }

        SecondBox.text = seconds >= 10 ? seconds.ToString() + ":" : "0" + seconds.ToString() + ":";
        MinuteBox.text = minutes >= 10 ? minutes.ToString() + ":" : "0" + minutes.ToString() + ":";
        MilleBox.text = milleSeconds.ToString("F0");
    }
}
