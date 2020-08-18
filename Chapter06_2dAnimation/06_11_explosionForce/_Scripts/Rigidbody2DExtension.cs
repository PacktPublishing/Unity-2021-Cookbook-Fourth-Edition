using UnityEngine;

// based on Unity Forums post by Swamy, Nov 21 2013
// https://forum.unity.com/threads/need-rigidbody2d-addexplosionforce.212173/?_ga=2.254273736.1942762606.1596193318-1007727082.1586283853#post-1426983

public static class Rigidbody2DExtension
{
    public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        Vector3 forceVector = (body.transform.position - explosionPosition);
        float wearoff = 1 - (forceVector.magnitude / explosionRadius);
        body.AddForce(forceVector.normalized * explosionForce * wearoff);
    }
}
