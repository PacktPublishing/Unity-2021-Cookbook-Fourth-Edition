using UnityEngine;

public class MouseOverDownHighlighter : MonoBehaviour
{
	public Color mouseOverColor = Color.yellow;
	public Color mouseDownColor = Color.green;

	private Material originalMaterial;
	private Material mouseOverMaterial;
	private Material mouseDownMaterial;
	private MeshRenderer meshRenderer;
	
	private bool mouseOver = false;

	void Start()
	{		
		meshRenderer = GetComponent<MeshRenderer>();
		originalMaterial = meshRenderer.sharedMaterial;
		mouseOverMaterial = NewMaterialWithColor(mouseOverColor);
		mouseDownMaterial = NewMaterialWithColor(mouseDownColor);

	}

	void OnMouseEnter()
	{
		mouseOver = true;
		meshRenderer.sharedMaterial = mouseOverMaterial;
	}
	
	void OnMouseDown()
	{
		meshRenderer.sharedMaterial = mouseDownMaterial;
	}
	
	void OnMouseUp()
	{
		if (mouseOver)
			OnMouseEnter();
		else
			OnMouseExit();
	}
	
	void OnMouseExit()
	{
		mouseOver = false;
		meshRenderer.sharedMaterial = originalMaterial;
	}

	private Material NewMaterialWithColor(Color newColor)
	{
		Material material = new Material(meshRenderer.sharedMaterial);
		material.color = newColor;

		return material;
	}
}
