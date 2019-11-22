using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLaunchScr : MonoBehaviour
{
    [SerializeField] Button rocket_btn;

    [SerializeField] Rigidbody Rocket;
    [SerializeField] Transform pointOfFire;
    [SerializeField] float bulletSpeed = 1.0f;

    [SerializeField] float fireRate = 1;
    [SerializeField] float lastShoot = 0;

    string btntext;
    [SerializeField]Sprite btnOn;
    [SerializeField]Sprite btnOff;
    private void Start()
    {
        btntext = rocket_btn.GetComponentInChildren<Text>().text;
    }

    void Update()
    {

    }
    public void Fire()
    {
        if (Time.time > lastShoot + fireRate)
        {
            lastShoot = Time.time;
            Rigidbody rocket = Instantiate(Rocket, pointOfFire.position, pointOfFire.transform.rotation);
            rocket.velocity = transform.TransformDirection(-Vector3.forward * bulletSpeed);

            rocket_btn.GetComponent<Image>().sprite = btnOff;
            rocket_btn.interactable = false;
            StartCoroutine(Uiflex());
        }
    }

    IEnumerator Uiflex()
    {
        while (Time.time <= lastShoot + fireRate)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            rocket_btn.GetComponentInChildren<Text>().text = $"Rocket\n<color=red>{Mathf.Abs(Time.time - lastShoot - fireRate).ToString("f2")}</color>";        //Колхоз
        }
        rocket_btn.GetComponent<Image>().sprite = btnOn;
        rocket_btn.interactable = true;
        rocket_btn.GetComponentInChildren<Text>().text = btntext;

    }
}

