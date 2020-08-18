using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCircle : MonoBehaviour
{
    public float power = 800f;
    public float radius = 3f;
    
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            print("Exploding ...");
            Explode();
        }
    }
    
    void Explode()
    {
        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rigidbody = hit.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(power, explosionPos, radius);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a red circle to show range of explosion radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
