using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCarColor : MonoBehaviour
{
    public static int CarColor; //1=Blue, 2=Red, 3=Green

    [SerializeField]
    private GameObject trackWindow;

    public void blueCar()
    {
        CarColor = 1;
        activateTrackWindow();
    }
    
    public void redCar()
    {
        CarColor = 2;
        activateTrackWindow();
    }
    
    public void greenCar()
    {
        CarColor = 3;
        activateTrackWindow();
    }

    private void activateTrackWindow()
    {
        trackWindow.SetActive(true);
    }
}
