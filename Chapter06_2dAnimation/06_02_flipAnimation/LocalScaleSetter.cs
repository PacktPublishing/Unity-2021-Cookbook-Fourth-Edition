using UnityEngine;

public class LocalScaleSetter : StateMachineBehaviour 
{
	public Vector3 scale = Vector3.one;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		animator.transform.localScale = scale;
	}
	
}
