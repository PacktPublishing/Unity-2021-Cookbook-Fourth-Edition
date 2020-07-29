using UnityEngine;

public class GlowManager : MonoBehaviour
{
	private string powerId = "Vector1_AA07C639";
	private string colorId = "Color_466BE55E";

	void Update () 
	{			
		if (Input.GetKeyDown("0"))
			GetComponent<Renderer>().material.SetFloat(powerId, 0);

		if (Input.GetKeyDown("1"))
			SetGlowColor(Color.red);

		if (Input.GetKeyDown("2"))
			SetGlowColor(Color.blue);
	}

	private void SetGlowColor(Color c)
	{		
		GetComponent<Renderer>().material.SetFloat(powerId, 5);
		GetComponent<Renderer>().material.SetColor(colorId, c);
	}
}
