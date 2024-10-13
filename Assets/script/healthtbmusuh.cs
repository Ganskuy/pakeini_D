using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthtbmusuh : MonoBehaviour
{
    public Slider slider;

    // Set the max health for the slider and set its initial value to max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update the slider's value to the current health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}