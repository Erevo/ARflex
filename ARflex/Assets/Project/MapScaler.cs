using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapScaler : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] int scale;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * Mathf.Clamp(slider.value, 0.1f, 1.0f)*scale;
    }

    public void ScaleMap()
    {
        //transform.localScale = Vector3.one * Mathf.Clamp(slider.value, 0.1f, 1.0f);
    }
}
