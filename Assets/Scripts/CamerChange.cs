using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerChange : MonoBehaviour
{
    public GameObject normalCam;
    public GameObject farCam;
    public GameObject frontCam;
    public int camMode;

    void Update()
    {
        if (Input.GetButtonDown("ViewMode"))
        {
            if (camMode == 2)
            {
                camMode = 0;
            }
            else
            {
                camMode++;
            }

            StartCoroutine(ModeChange());
        }
    }

    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (camMode == 0)
        {
            normalCam.SetActive(true);
            frontCam.SetActive(false);
        } else if (camMode == 1)
        {
            farCam.SetActive(true);
            normalCam.SetActive(false);
        }
        else
        {
            frontCam.SetActive(true);
            farCam.SetActive(false);
        }
    }
}
