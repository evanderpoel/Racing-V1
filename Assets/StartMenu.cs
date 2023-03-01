using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public GameObject startMenuCanvas;
    public GameObject mapHolder;
    public Button startButton;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
    }

    void beginRace()
    {
        mapHolder.SetActive(true);
        startMenuCanvas.SetActive(false);
    }

}
