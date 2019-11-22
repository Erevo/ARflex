using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    void Start()
    {
        transform.SetParent(GameObject.Find("Map").transform);
        Physics.IgnoreLayerCollision(8,8);
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Destroy(gameObject, 5);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
