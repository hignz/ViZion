using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour
{
    public GameObject ObjectToTrack;
    public float TrackingRange = 5;
    private bool isTracking = false;

    void Update()
    {
        if (Vector2.Distance(
            transform.position, ObjectToTrack.transform.position) <= TrackingRange)
        {
            isTracking = true;
        }
        else
        {
            isTracking = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (isTracking)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
      
        Gizmos.DrawWireSphere(transform.position, TrackingRange);
        Gizmos.DrawLine(transform.position, ObjectToTrack.transform.position);
    }
}
