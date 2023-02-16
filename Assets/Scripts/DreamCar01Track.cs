using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCar01Track : MonoBehaviour
{

    public GameObject theMarker;
    public GameObject Markers;
    public int markTracker;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("DreamCar01"))
        {
            theMarker.transform.position = Markers.transform.GetChild(markTracker).position;
            this.GetComponent<BoxCollider>().enabled = false;
            markTracker += 1;
            
            if (markTracker == Markers.GetComponentsInChildren<Transform>().Length-1)
            {
                markTracker = 0;
            }

            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}
