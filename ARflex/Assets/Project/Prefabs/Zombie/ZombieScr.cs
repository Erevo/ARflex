using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScr : MonoBehaviour
{
    //[SerializeField] GameObject Map;
    [SerializeField] GameObject House;
    [SerializeField] HouseScr HouseScr;

    public int heal = 100;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] int z_damage = 100;

    float lastDamage;
    void OnEnable()
    {
        House = GameObject.FindGameObjectWithTag("House");
        HouseScr = House.GetComponent<HouseScr>();
    }

    public void Death()
    {
        speed = 0;
        GetComponent<Animator>().Play("Z_FallingBack");
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2);
    }
    void Damage()
    {
        HouseScr.HouseHP -= z_damage;
    }

    void Update()
    {
        if (heal <= 0)
        {
            Death();
        }


        rb.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        transform.LookAt(House.transform);
    }

    private void OnCollisionEnter(Collision col)
    {
        switch (col.collider.name)
        {
            case "Bullet(Clone)":
                heal -= 55;
                break;
            case "House":
                GetComponent<Animator>().Play("Z_Attack");
                speed = 0;
                break;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.collider.name == "House")
        {
            if(Time.time > lastDamage + 2f)
            {
                Damage();
                lastDamage = Time.time;
            }
        }
    }
}
