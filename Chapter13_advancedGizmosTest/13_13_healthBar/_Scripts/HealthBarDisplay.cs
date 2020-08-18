using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour 
{
    public Image healthMeterFiller;

    private void OnEnable()
    {
        Player.OnHealthChange += UpdateHealthBar;
    }

    private void OnDisable()
    {
        Player.OnHealthChange -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float health)
    {
        healthMeterFiller.fillAmount = health;
    }
}
