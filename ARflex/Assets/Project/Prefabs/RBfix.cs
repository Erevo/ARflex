using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class RBfix : MonoBehaviour
{
    TrackableBehaviour Mark;
    Rigidbody rb;
    RigidbodyConstraints constraints;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        constraints = rb.constraints;
        Mark = GameObject.Find("VuMark").GetComponent<TrackableBehaviour>();
    }

    void Update()
    {
        if (Mark.CurrentStatus != TrackableBehaviour.Status.NO_POSE)
            rb.constraints = constraints;
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
    }
}
