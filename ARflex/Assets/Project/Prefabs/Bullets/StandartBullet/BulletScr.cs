using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    [SerializeField]GameObject cubepr;
    void Start()
    {
        Physics.IgnoreLayerCollision(8,8);
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Destroy(gameObject, 5);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(cubepr,transform);
        //cube.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
