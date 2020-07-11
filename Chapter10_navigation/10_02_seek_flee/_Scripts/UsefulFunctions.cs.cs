using UnityEngine;

public class UsefulFunctions : MonoBehaviour
{
    public static void DebugRay(Vector3 origin, Vector3 destination, Color c)
    {
        Vector3 direction = destination - origin;
        Debug.DrawRay(origin, direction, c);
    }
}