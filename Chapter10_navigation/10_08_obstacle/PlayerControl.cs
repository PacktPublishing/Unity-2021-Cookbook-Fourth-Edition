using UnityEngine;

public class PlayerControl : MonoBehaviour 
{	
	public float y;
	
	public const float MIN_X = -15;
	public const float MAX_X = 15;
	public const float MIN_Z = -10;
	public const float MAX_Z = 10;
	
	private float speed = 20;
	
	private void Awake()
	{
		y = transform.position.y;
	}

	private void Update () 
	{
		KeyboardMovement();
		CheckBounds();
	}
	
	private void KeyboardMovement()
	{
		float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		transform.Translate( new Vector3(dx,y,dz) );		
	}
	
	private void CheckBounds()
	{
		float x = transform.position.x;
		float z = transform.position.z;		
		x = Mathf.Clamp(x, MIN_X, MAX_X);
		z = Mathf.Clamp(z, MIN_Z, MAX_Z);		
		transform.position = new Vector3(x, y, z);
	}
}
