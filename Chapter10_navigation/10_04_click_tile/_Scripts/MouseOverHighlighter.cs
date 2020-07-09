using UnityEngine;

public class MouseOverHighlighter : MonoBehaviour 
{
	private MeshRenderer meshRenderer;
	private Material originalMaterial;

	void Start()
	{		
		meshRenderer = GetComponent<MeshRenderer>();
		originalMaterial = meshRenderer.sharedMaterial;
	}
	void OnMouseOver()
	{
		meshRenderer.sharedMaterial = NewMaterialWithColor(Color.yellow);
	}
	
	void OnMouseExit()
	{
		meshRenderer.sharedMaterial = originalMaterial;
	}

	private Material NewMaterialWithColor(Color newColor)
	{
		Shader shaderSpecular = Shader.Find("Specular");
		Material material = new Material(shaderSpecular);
		material.color = newColor;

		return material;
	}
}
