using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGridGizmo : MonoBehaviour
{
    /**
     * we've moved!
     * snap position to its grid
     */
    public void Update()
    {
#if UNITY_EDITOR
        transform.parent.GetComponent<GridGizmo>().SnapPositionToGrid(transform);
#endif
    }
    
}
