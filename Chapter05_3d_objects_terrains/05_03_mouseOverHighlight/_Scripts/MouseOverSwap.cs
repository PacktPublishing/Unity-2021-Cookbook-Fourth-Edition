using UnityEngine;

public class MouseOverSwap : MonoBehaviour 
{
	// link to material to use when detect mouse over
	public Material mouseOverMaterial;
	
	// copy of pre-highlight material
	private Material _originalMaterial;
	
	// reference to renderer so we can change materials
	private MeshRenderer _meshRenderer;

	void Start()
	{		
		// get reference to renderer
		_meshRenderer = GetComponent<MeshRenderer>();
		
		// copy material before we do anything
		_originalMaterial = _meshRenderer.sharedMaterial;
	}
	
	void OnMouseOver()
	{
		// when mouse over object, change to mouse over material
		_meshRenderer.sharedMaterial = mouseOverMaterial;
	}
	
	void OnMouseExit()
	{
		// when mouse moves away from object, change back to original material
		_meshRenderer.sharedMaterial = _originalMaterial;
	}
}
