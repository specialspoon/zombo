using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasHandler : MonoBehaviour
{
    public float health;
    public PlayerHealth playerHealth;
    public Slider healthSlider;

    public void Update()
    {
        health = playerHealth.health;
        healthSlider.value = health;
    }
}
