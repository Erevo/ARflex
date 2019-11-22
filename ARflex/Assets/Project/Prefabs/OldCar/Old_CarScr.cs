using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Vuforia;

public class CarScr : MonoBehaviour
{
    [SerializeField] GameObject Map;
    Rigidbody rb;
    [SerializeField] float speed = 4f;
    void Start()
    {
        Map = GameObject.Find("Plane");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (!Map.GetComponent<MeshRenderer>().enabled)
        //{
        //    rb.constraints = RigidbodyConstraints.FreezeAll;
        //    return;
        //}
        //else
        //{
        //    rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        //}

        //if (Mark.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        //    rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        //else
        //{
        //    rb.constraints = RigidbodyConstraints.FreezeAll;
        //    return;
        //}


        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, rb.velocity.y, y);
        rb.velocity = transform.TransformDirection(movement * speed);

        if (x != 0 && y != 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (rb.velocity.magnitude > 0.01f && col.gameObject.tag == "Zombie")
        {
            col.gameObject.GetComponent<ZombieScr>().Death();
        }
    }
}
