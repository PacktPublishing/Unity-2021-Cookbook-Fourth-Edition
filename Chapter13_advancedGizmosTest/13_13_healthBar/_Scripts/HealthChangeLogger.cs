using UnityEngine;

public class HealthChangeLogger 
{
    // constructor - register listener
    public HealthChangeLogger()
    {
        Player.OnHealthChange += LogNewHealth;
    }

    // finalizaer - unregister listener to avoid memory leaks
    ~HealthChangeLogger()
    {
        Player.OnHealthChange -= LogNewHealth;
    }

    public void LogNewHealth(float health)
    {
        // 1 decimal place
        string healthAsString = health.ToString("0.0");
        Debug.Log("health = " + healthAsString);
    }
}
