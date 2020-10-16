using UnityEngine;

public class LaserDisplay : MonoBehaviour
{
    public float lineWidth = 0.2f;
    public float lineLength = 2;
    public Color color = Color.white;
    public Material material;
    public float rotationSpeed = 0.1f;
    
    private LineRenderer _lineRenderer;
    
    void Awake()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = material;
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = lineWidth;
    }

    void Update () 
    {
        _lineRenderer.material.SetColor("_Color", color);
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 lineStart = transform.position;
        Vector3 lineEnd =  transform.position + forward * lineLength; 
        
        _lineRenderer.SetPosition(0, lineStart);
        _lineRenderer.SetPosition(1, lineEnd);
        
        transform.Rotate(0, rotationSpeed, 0);    
    }
}
