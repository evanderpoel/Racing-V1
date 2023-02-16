using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayTrigger : MonoBehaviour
{

    public GameObject lapCompleteTrigger;
    public GameObject halfwayTrigger;

    private void OnTriggerEnter(Collider other)
    {
        lapCompleteTrigger.SetActive(true);
        halfwayTrigger.SetActive(false);
    }
}
