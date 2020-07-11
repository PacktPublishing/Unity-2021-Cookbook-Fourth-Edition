using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject wayPoint0;
    public GameObject wayPoint3;

    public GameObject NextWaypoint(GameObject current)
    {
        if (current == wayPoint0)
            return wayPoint3;

        return wayPoint0;
    }
}
