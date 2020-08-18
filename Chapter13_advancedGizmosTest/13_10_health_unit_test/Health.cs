using UnityEngine;
using System.Collections;

public class Health 
{
    /// <summary>
    /// The health - ranges from 0.0 (dead) to 1.0 (full health)
    /// </summary>
    private float _health = 1;

    /// <summary>
    /// Gets the health.
    /// </summary>
    /// <returns>The health.</returns>
    public float GetHealth()
    {
        return _health;
    }

    /// <summary>
    /// Adds to the health.
    /// </summary>
    /// <returns><c>true</c>, if health was added, <c>false</c> otherwise (if invalid value)</returns>
    /// ensure health does not go about 1.0
    /// <param name="heathPlus">Heath plus.</param>
    public bool AddHealth(float heathPlus)
    {
        if(heathPlus > 0){
            _health += heathPlus;
            if (_health > 1) {
                _health = 1;
            }
            return true;
        } else {
            return false;
        }
    }

    public bool KillCharacter()
    {
        _health = 0;
        return true;
    }
}
