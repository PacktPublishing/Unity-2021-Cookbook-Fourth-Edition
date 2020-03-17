using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // top-right - maximum player position
    // only visible at design-time
    public Transform corner_max;

    // bottom-left - minimum player position
    // only visible at design-time
    public Transform corner_min;

    // movement speed multiplier
    public float speed = 40;

    // reference to rigidbody2D so we can apply force to GameObject
    private Rigidbody rigidBody;

    /*
     * variables for max/min X and Y values
     * extracted from corner_min/max at run time
     */
    private float x_min;
    private float x_max;
    private float z_min;
    private float z_max;

    /*----------------------------------------------------------
     * cache rigidbody component reference
     * read max/min values from corner GameObjects
     */
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        x_max = corner_max.position.x;
        x_min = corner_min.position.x;
        z_max = corner_max.position.z;
        z_min = corner_min.position.z;
    }

    /*----------------------------------------------------------*/
    // each frame - move object, then clamp within range
    void FixedUpdate()
    {
        KeyboardMovement();
        KeepWithinMinMaxRectangle();
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

        // restrict player movement
        KeepWithinMinMaxRectangle();
    }

    /*----------------------------------------------------------
     * using max/min values, ensure position of parent GameObject
     * is clamped within these ranges
     * so set position to clamped values - moving object into range if required
     */
    private void KeepWithinMinMaxRectangle()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float clampedX = Mathf.Clamp(x, x_min, x_max);
        float clampedZ = Mathf.Clamp(z, z_min, z_max);
        transform.position = new Vector3(clampedX, y, clampedZ);
    }

    /*----------------------------------------------------------
     * draw nice yellow rectangle in Scene panel
     * to visually show game designer the limits
     * that the player's character will be restricted within
     */
    void OnDrawGizmos()
    {
        Vector3 top_right = Vector3.zero;
        Vector3 bottom_right = Vector3.zero;
        Vector3 bottom_left = Vector3.zero;
        Vector3 top_left = Vector3.zero;

        if (corner_max && corner_min)
        {
            top_right = corner_max.position;
            bottom_left = corner_min.position;

            bottom_right = top_right;
            bottom_right.z = bottom_left.z;

            top_left = bottom_left;
            top_left.z = top_right.z;
        }

        //Set the following gizmo colors to YELLOW
        Gizmos.color = Color.yellow;

        //Draw 4 lines making a rectangle
        Gizmos.DrawLine(top_right, bottom_right);
        Gizmos.DrawLine(bottom_right, bottom_left);
        Gizmos.DrawLine(bottom_left, top_left);
        Gizmos.DrawLine(top_left, top_right);
    }

}
