using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z_CarScr : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]int HP = 100;
    [SerializeField]GameObject HealBar;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (rb.velocity.magnitude > 0.01f && col.gameObject.tag == "Zombie")
        {
            col.gameObject.GetComponent<ZombieScr>().Death();
            HP--;
            HealBar.GetComponent<MeshRenderer>().material.color = Color.Lerp(HealBar.GetComponent<MeshRenderer>().material.color, Color.red, 0.01f);
        }
    }
}
