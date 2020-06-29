using UnityEngine;
using System.Collections;

public class WaterBlock : MonoBehaviour
{
	// cached reference to our sibling Animator Controller component
	private Animator animatorController;

	//----------------------------------
	void Start()
	{
		// get reference to sibling Animator component
		animatorController = GetComponent<Animator>();
	}

	//----------------------------------
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit GameObject tagged 'Player'
		// THEN set the Animator trigger boolean value for 'Fail'
		if(hit.CompareTag("Player")){
			animatorController.SetTrigger("Fall");
		}
	}
}
