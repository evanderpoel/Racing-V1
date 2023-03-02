using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColor : MonoBehaviour
{
    [SerializeField]
    private GameObject blueBody;
    [SerializeField]
    private GameObject redBody;
    [SerializeField]
    private GameObject greenBody;
    [SerializeField]
    private GameObject blueMudGaurdLeft;
    [SerializeField]
    private GameObject redMudGaurdLeft;
    [SerializeField]
    private GameObject greenMudGaurdLeft;
    [SerializeField]
    private GameObject blueMudGaurdRight;
    [SerializeField]
    private GameObject redMudGaurdRight;
    [SerializeField]
    private GameObject greenMudGaurdRight;
    private int carChoice;
    void Start()
    {
        carChoice = GlobalCarColor.CarColor;

        if (carChoice == 1)
        {
            blueBody.SetActive(true);
            blueMudGaurdLeft.SetActive(true);
            blueMudGaurdRight.SetActive(true);
        } else if (carChoice == 2)
        {
            redBody.SetActive(true);
            redMudGaurdLeft.SetActive(true);
            redMudGaurdRight.SetActive(true);
        }
        else
        {
            greenBody.SetActive(true);
            greenMudGaurdLeft.SetActive(true);
            greenMudGaurdRight.SetActive(true);
        }
    }

}
