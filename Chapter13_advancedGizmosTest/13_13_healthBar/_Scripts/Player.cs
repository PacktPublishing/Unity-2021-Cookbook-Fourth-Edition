using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public delegate void HealthChangeAction(float health);
    public static event HealthChangeAction OnHealthChange;

    private float health;
    const float MIN_HEALTH = 0;
    const float MAX_HEALTH = 1;

    public float GetHealth()
    {
        return this.health;
    }

    public Player(float health = 1)
    {
        this.health = health;

        // ensure initial value published
        PublishHealthChangeEvent();
    }

    public void AddHealth(float amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount may not be less than Zero");

        this.health += amount;
        if (this.health > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        PublishHealthChangeEvent();
    }

    public void ReduceHealth(float amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount may not be less than Zero");

        this.health -= amount;
        if (this.health < MIN_HEALTH)
        {
            this.health = MIN_HEALTH;
        }
        PublishHealthChangeEvent();
    }

    // event
    private void PublishHealthChangeEvent()
    {
        if (null != OnHealthChange)
            OnHealthChange(this.health);
    }
}
