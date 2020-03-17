using UnityEngine;

public class FireProjectile : MonoBehaviour 
{
    // minimum time between new projectiles
    // (stops them hitting each other as they are fired)
    const float FIRE_DELAY = 0.25f;
    
    // number of seconds until projectile is destroyed
    // (stops the scene becoming filled up with old projectiles)
    const float PROJECTILE_LIFE = 1.5f;
    
    // reference to PREFAB whose instances will be used as projectiles
    public Rigidbody projectilePrefab;
    
    // speed - force multiplier
    public float projectileSpeed = 500f;

    // used to determine whether we are yet allowed to fire another projectile
    private float nextFireTime = 0;

    // each frame - check to see if we have reached the time 
    // we are next allowed to fire a projectile
    void Update() 
    {
        if (Time.time > nextFireTime)
        {
            // if so, then see if Fire key is pressed
            CheckFireKey();            
        }
    }

    // if FIRE1 key pressed
    // THEN create a new projectile object, moving in direction the parent GameObject is facing
    private void CheckFireKey() 
    {
        if(Input.GetButton("Fire1")) {
            // create projectile instance
            CreateProjectile();
            
            // set next time allowed to fire as current time + time between projectiles
            nextFireTime = Time.time + FIRE_DELAY;
        }
    }
    
    // create a new projectile object, moving in direction the parent GameObject is facing
    private void CreateProjectile() 
    {
        // get parent game object's position and rotation
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // create instance of prefab, at position and rotation
        // (and store a reference to the Rigid Body in the new GameObject)
        Rigidbody projectileRigidBody = Instantiate(projectilePrefab, position, rotation);
        
        // set velocity to be fowards * speed
        Vector3 projectileVelocity = transform.TransformDirection(Vector3.forward * projectileSpeed);

        // move projectile forwards by applying the force to the rigid body
        projectileRigidBody.AddForce(projectileVelocity);

        // get a reference to the projectile GameObject
        GameObject projectileGO = projectileRigidBody.gameObject;
        
        // tell Unity to destroy the projectile after the projectile life number of seconds
        Destroy(projectileGO, PROJECTILE_LIFE);
    }
} 