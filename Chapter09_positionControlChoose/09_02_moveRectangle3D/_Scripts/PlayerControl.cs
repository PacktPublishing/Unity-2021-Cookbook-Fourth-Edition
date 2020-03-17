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

    /*
     * the new velocity for the object based on user inputs
     */
    private Vector3 newVelocity;

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
    // basic 3D character movement based on inputs
    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float xSpeed = xMove * speed;
        float zSpeed = zMove * speed;

        newVelocity = new Vector3(xSpeed, 0, zSpeed);
    }
    
    /*----------------------------------------------------------*/
    // each frame - move object, then clamp within range
    void FixedUpdate()
    {
        rigidBody.velocity = newVelocity;
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
//        Gizmos.DrawLine(top_right, bottom_right);
//        Gizmos.DrawLine(bottom_right, bottom_left);
//        Gizmos.DrawLine(bottom_left, top_left);
//        Gizmos.DrawLine(top_left, top_right);

        DrawThickLine(top_right, bottom_right, 5);
        DrawThickLine(bottom_right, bottom_left, 5);
        DrawThickLine(bottom_left, top_left, 5);
        DrawThickLine(top_left, top_right, 5);

    }
    
    // from
    // https://answers.unity.com/questions/1139985/gizmosdrawline-thickens.html
    public static void DrawThickLine(Vector3 p1, Vector3 p2, float width)
    {
        int count = 1 + Mathf.CeilToInt(width); // how many lines are needed.
        if (count == 1)
        {
            Gizmos.DrawLine(p1, p2);
        }
        else
        {
            Camera c = Camera.current;
            if (c == null)
            {
                Debug.LogError("Camera.current is null");
                return;
            }
            var scp1 = c.WorldToScreenPoint(p1);
            var scp2 = c.WorldToScreenPoint(p2);
 
            Vector3 v1 = (scp2 - scp1).normalized; // line direction
            Vector3 n = Vector3.Cross(v1, Vector3.forward); // normal vector
 
            for (int i = 0; i < count; i++)
            {
                Vector3 o = 0.99f * n * width * ((float)i / (count - 1) - 0.5f);
                Vector3 origin = c.ScreenToWorldPoint(scp1 + o);
                Vector3 destiny = c.ScreenToWorldPoint(scp2 + o);
                Gizmos.DrawLine(origin, destiny);
            }
        }
    }
}
