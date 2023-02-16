using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarController : MonoBehaviour
{
    public GameObject carControl;
    public GameObject dreamCar;
    
    // Start is called before the first frame update
    void Start()
    {
        carControl.GetComponent<CarUserControl>().enabled = true;
        dreamCar.GetComponent<CarAIControl>().enabled = true;
    }
    
}
