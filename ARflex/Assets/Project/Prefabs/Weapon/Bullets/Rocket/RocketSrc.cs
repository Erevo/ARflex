using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSrc : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 8);
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] zombies = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius * transform.localScale.x, LayerMask.GetMask("Zombie"));
        //var zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (var zombie in zombies)
        {
            zombie.GetComponent<ZombieScr>().Death();
        }
        Destroy(gameObject);
    }
}
