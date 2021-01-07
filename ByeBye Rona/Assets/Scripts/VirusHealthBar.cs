using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusHealthBar : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = FindObjectOfType<Camera>();
    }

    public void SetHealth(float health, float maxhealth)
    {
        //only display health bar when the enemy has been hit
        slider.gameObject.SetActive(health < maxhealth);
        slider.value = health;
        slider.maxValue = maxhealth;
    }
    void Update()
    {
        slider.transform.position =transform.parent.position + offset;
    }
}
