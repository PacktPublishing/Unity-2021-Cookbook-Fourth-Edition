using UnityEngine;

public class ExplodeTagged : MonoBehaviour
{
    public string tagName = "Bug";
    public float force = 800f;
    public float radius = 3f;

    private GameObject[] _gameObjects;    

    private void Awake()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag(tagName);
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            Explode();
        }
    }
	
    // add explosion force to child objects           
    private void Explode()
    {
        foreach(GameObject gameObject in _gameObjects){
            Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.AddExplosionForce(force, transform.position, radius);
        }
    }
	
}