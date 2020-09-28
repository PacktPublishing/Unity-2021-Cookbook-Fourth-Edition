using UnityEngine;

public class FlipCamera : MonoBehaviour
{
    private Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    
    void OnPreCull () 
    {
        _camera.ResetWorldToCameraMatrix ();
        _camera.ResetProjectionMatrix ();
        _camera.projectionMatrix = _camera.projectionMatrix * Matrix4x4.Scale(new Vector3 (-1, 1, 1));
    }
     
    void OnPreRender () 
    {
        GL.invertCulling = true;
    }
     
    void OnPostRender () 
    {
        GL.invertCulling = false;
    }
}
