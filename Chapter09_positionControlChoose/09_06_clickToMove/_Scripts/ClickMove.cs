using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ClickMove : MonoBehaviour 
{
    public float multiplier = 500f;
    //public GameObject projectilePrefab;

    private Rigidbody rigidBody;

	private void Awake()
	{
        rigidBody = GetComponent<Rigidbody>();		
	}

    void OnMouseDown()
    {
        float x = RandomDirectionComponent();
        float y = RandomDirectionComponent();
        float z = RandomDirectionComponent();
        Vector3 randomDirection = new Vector3(x,y,z);
        rigidBody.AddForce(randomDirection);
    }

    // return a random value in range -0.5 ... 0.5 * multiplier
    private float RandomDirectionComponent()
    {
        return (Random.value - 0.5f) * multiplier;
    }

}
