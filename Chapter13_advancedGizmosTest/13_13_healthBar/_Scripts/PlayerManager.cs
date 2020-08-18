using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player player;
    private HealthChangeLogger healthChangeLogger;

    void Start()
    {
        player = new Player();
        healthChangeLogger = new HealthChangeLogger();
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
            AddToHealth();

        if (Input.GetKeyDown("down"))
            ReduceHealth();
    }

    public void AddToHealth()
    {
        player.AddHealth(0.5f);
    }

    public void ReduceHealth()
    {
        player.ReduceHealth(0.1f);
    }
}
