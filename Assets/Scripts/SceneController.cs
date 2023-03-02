using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void startRace()
    {
        SceneManager.LoadScene("Track01");
    }

    public void trackSelection()
    {
        SceneManager.LoadScene("TrackSelection");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
