using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunScr : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody Bullet;
    [SerializeField] Transform pointOfFire;
    [SerializeField] float bulletSpeed = 1.0f;

    public float fireRate = 1;
    float lastShoot;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > lastShoot + fireRate)
            {
                lastShoot = Time.time;
                Rigidbody bullet = Instantiate(Bullet, pointOfFire.position, pointOfFire.transform.rotation);
                bullet.velocity = transform.TransformDirection(Vector3.left * bulletSpeed);
                anim.SetBool("Shoot", true);
            }
            else
                anim.SetBool("Shoot", false);
        }
    }
}
