using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{
    GameObject RocketLaunch;
    GameObject MiniGun;
    void Start()
    {
        RocketLaunch = GameObject.FindGameObjectWithTag("RocketLaunch");
        MiniGun = GameObject.FindGameObjectWithTag("MachineGun");
    }

    void FixedUpdate()
    {

        //foreach (var touch in Input.touches)
        //{
        //    if (touch.position.x > Screen.width / 2)
        //    {
        //        MiniGun.GetComponent<MinigunScr>().Fire();
        //    }
        //    else if (touch.position.x < Screen.width / 2)
        //        RocketLaunch.GetComponent<RocketLaunchScr>().Fire();
        //}
        foreach (var touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
                MiniGun.GetComponent<MinigunScr>().Fire();
        }
    }

    public void RocketFire()
    {
        RocketLaunch.GetComponent<RocketLaunchScr>().Fire();
    }
}

