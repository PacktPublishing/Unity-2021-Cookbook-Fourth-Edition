using UnityEngine;

public class SimplePlayerControl : MonoBehaviour
{
    // movement speed multiplier
    public float speed = 1000;

    // reference to rigidbody2D so we can apply force to GameObject
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    /*----------------------------------------------------------*/
    // each frame - move object, then clamp within range
    void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 newVelocy = new Vector3(xMove, 0, zMove);

        rigidBody.velocity = newVelocy;
    }
}
