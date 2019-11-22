using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseScr : MonoBehaviour
{
    public int HouseHP = 10000;
    [SerializeField] GameObject text;


    void Update()
    {
        if (HouseHP <= 0) HouseDestroed();

        text.GetComponent<TextMesh>().text = HouseHP.ToString();
    }

    void HouseDestroed()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
