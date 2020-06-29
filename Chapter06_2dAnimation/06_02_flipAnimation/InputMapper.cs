using UnityEngine;

public class InputMapper : MonoBehaviour 
{
	Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}
	
	void Update() {
		animator.SetFloat("axisHorizontal", Input.GetAxisRaw("Horizontal"));
	}
}
