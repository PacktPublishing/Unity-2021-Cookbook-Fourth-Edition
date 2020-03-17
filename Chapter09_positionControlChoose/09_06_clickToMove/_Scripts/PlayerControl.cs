using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // movement speed multiplier
    public float speed = 40;

    // reference to rigidbody2D so we can apply force to GameObject
    private Rigidbody rigidBody;


    /*----------------------------------------------------------
     * cache rigidbody component reference
     * read max/min values from corner GameObjects
     */
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    /*----------------------------------------------------------*/
    // each frame - move object, then clamp within range
    void FixedUpdate()
    {
        KeyboardMovement();
    }

    /*----------------------------------------------------------*/
    // basic 3D character movement
    private void KeyboardMovement()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float xSpeed = xMove * speed;
        float zSpeed = zMove * speed;

        Vector3 newVelocy = new Vector3(xSpeed, 0, zSpeed);

        rigidBody.velocity = newVelocy;


    }



}
