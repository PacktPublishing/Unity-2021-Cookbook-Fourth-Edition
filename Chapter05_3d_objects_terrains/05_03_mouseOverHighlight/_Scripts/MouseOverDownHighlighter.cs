using UnityEngine;

public class MouseOverDownHighlighter : MonoBehaviour
{
	public Color mouseOverColor = Color.yellow;
	public Color mouseDownColor = Color.green;

	private Material _originalMaterial;
	private Material _mouseOverMaterial;
	private Material _mouseDownMaterial;
	private MeshRenderer _meshRenderer;

	// true/false flag indicating if mouse is over object
	private bool _mouseOver = false;

	
	// get reference to renderer
	// copy original material (so it can be reinstated later)
	// create 2 new materials for mouse over / mouse down
	void Awake()
	{		
		_meshRenderer = GetComponent<MeshRenderer>();
		_originalMaterial = _meshRenderer.sharedMaterial;
		_mouseOverMaterial = NewMaterialWithColor(mouseOverColor);
		_mouseDownMaterial = NewMaterialWithColor(mouseDownColor);

	}

	// mouse is over object (but mouse button not down)
	// so change material to mouse over material
	void OnMouseEnter()
	{
		_mouseOver = true;
		_meshRenderer.sharedMaterial = _mouseOverMaterial;
	}

	// mouse button clicked on onbject
	// so change material to the mouse down material
	void OnMouseDown()
	{
		_meshRenderer.sharedMaterial = _mouseDownMaterial;
	}

	// mouse button released
	// if mouse still over object then re-execute OnMouseEnter
	// else mouse is away from object to invoke OnMouseExit
	void OnMouseUp()
	{
		if (_mouseOver)
			OnMouseEnter();
		else
			OnMouseExit();
	}
	
	// mouse has moved away from object
	// so record mouse is not over, and return object to original material
	void OnMouseExit()
	{
		_mouseOver = false;
		_meshRenderer.sharedMaterial = _originalMaterial;
	}

	// create and return a new Material object using the given color
	private Material NewMaterialWithColor(Color newColor)
	{
		Material material = new Material(_meshRenderer.sharedMaterial);
		material.color = newColor;

		return material;
	}
}
