using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Vehicles.Car;

public class CompleteLap : MonoBehaviour
{
    public GameObject finishLineTrigger;
    public GameObject halfwayTrigger;
    public GameObject mainCanvas;
    public GameObject finishCube;
    public GameObject MyCar;
    public GameObject LevelMusic;
    [SerializeField] private GameObject userAITracker;

    public TMP_Text minuteDisplay;
    public TMP_Text secondDisplay;
    public TMP_Text milleSecondDisplay;
    public TMP_Text totalLapTime;
    public TMP_Text totalBestLapTime;
    
    private float lapTime;
    private float bestLapTime;
    private float totalTime;

    public TMP_Text lapCounter;
    private int currentLap = 1;
    public int lapRequirement;


    public GameObject CompleteRaceScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            bestLapTime = getBestLapTime();
            lapTime = getLapTime();
            totalTime += lapTime;
            //Setting Best Lap Time
            if (isShortestLap() || isFirstLap())
            {
                secondDisplay.text = LapTimeManager.seconds >= 10
                    ? LapTimeManager.seconds.ToString() + ":"
                    : "0" +
                      LapTimeManager.seconds.ToString() + ":";
                minuteDisplay.text = LapTimeManager.minutes >= 10
                    ? LapTimeManager.minutes.ToString() + ":"
                    : "0" +
                      LapTimeManager.minutes.ToString() + ":";

                milleSecondDisplay.text = LapTimeManager.milleSeconds.ToString("F0");
                totalBestLapTime.text =
                    "Best Lap: " + minuteDisplay.text + secondDisplay.text + milleSecondDisplay.text;
            }

            if (currentLap == lapRequirement)
            {
                completeRaceSequence();
            }
            else
            {
                incrementLapDisplay();

                LapTimeManager.minutes = 0;
                LapTimeManager.seconds = 0;
                LapTimeManager.milleSeconds = 0;

                //Reset Checkpoints
                finishLineTrigger.SetActive(false);
                halfwayTrigger.SetActive(true);
            }
        }
    }

    private float getBestLapTime()
    {
        return (int.Parse(Regex.Replace(minuteDisplay.text, "[^0-9]", "")) * 60 +
                int.Parse(Regex.Replace(secondDisplay.text, "[^0-9]", ""))) * 1000 +
               float.Parse(Regex.Replace(milleSecondDisplay.text, "[^0-9]", ""));
    }

    private float getLapTime()
    {
        return (LapTimeManager.minutes * 60 + LapTimeManager.seconds) * 1000 + LapTimeManager.milleSeconds;
    }

    private Boolean isShortestLap()
    {
        return bestLapTime >
               lapTime;
    }

    private Boolean isFirstLap()
    {
        return currentLap == 1;
    }

    private void completeRaceSequence()
    {
        calculateAndSetFinalTime();
        MyCar.GetComponent<CarUserControl>().enabled = false;
        userAITracker.SetActive(true);
        MyCar.GetComponent<CarAudio>().enabled = false;
        MyCar.GetComponent<CarAIControl>().enabled = true;
        MyCar.GetComponent<WaypointProgressTracker>().enabled = true;
        LevelMusic.SetActive(false);
        
        mainCanvas.SetActive(false);
        finishCube.SetActive(true);
        CompleteRaceScreen.SetActive((true));
        finishLineTrigger.SetActive(false);
        halfwayTrigger.SetActive(false);
    }

    private void calculateAndSetFinalTime()
    {
        totalLapTime.text = "Race Time: " + TimeSpan.FromMilliseconds(totalTime).ToString(@"mm\:ss\:f");
    }

    private void incrementLapDisplay()
    {
        currentLap++;
        lapCounter.text = currentLap + "/" + lapRequirement;
    }
}
