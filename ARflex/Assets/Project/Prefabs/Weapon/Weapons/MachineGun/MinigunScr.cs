using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunScr : MonoBehaviour
{
    Animator anim;
    public ParticleSystem particle;
    [SerializeField] Rigidbody Bullet;
    [SerializeField] Transform pointOfFire;
    [SerializeField] float bulletSpeed = 1.0f;

    [SerializeField] float fireRate = 1;
    [SerializeField] float lastShoot = 100;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Fire()
    {
        if (Time.time > lastShoot + fireRate)
        {
            particle.Play();
            lastShoot = Time.time;
            Rigidbody bullet = Instantiate(Bullet, pointOfFire.position, pointOfFire.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.left * bulletSpeed);
            anim.SetTrigger("Shoot");
            particle.Stop();
        }
    }
}
