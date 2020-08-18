using UnityEngine;

public class SphereController : MonoBehaviour 
{
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Push();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            Push();
    }

    void Push()
    {
        rigidbody.AddForce(Vector3.forward * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            other.GetComponent<Animator>().SetBool("Opening", true);
            StopMoving();
        }
    }

    void StopMoving()
    {
        rigidbody.velocity = Vector3.zero;
    }
}
