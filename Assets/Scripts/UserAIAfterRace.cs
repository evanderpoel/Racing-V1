using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAIAfterRace : MonoBehaviour
{

    public GameObject theMarker;
    public GameObject Markers;
    public int markTracker;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("DreamCar01"))
        {
            theMarker.transform.position = Markers.transform.GetChild(markTracker).position;
            this.GetComponent<SphereCollider>().enabled = false;
            markTracker += 1;
            
            if (markTracker == Markers.GetComponentsInChildren<Transform>().Length-1)
            {
                markTracker = 0;
            }

            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SphereCollider>().enabled = true;
        }
        
    }
}
