using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStablize : MonoBehaviour
{

    public GameObject theCar;

    public float carX;
    public float carY;
    public float carZ;

    // Update is called once per frame
    void Update()
    {
        Vector3 carAnlges = theCar.transform.eulerAngles;
        carX = carAnlges.x;
        carY = carAnlges.y;
        carZ = carAnlges.z;

        transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
    }
}
