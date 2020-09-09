using UnityEngine;
using Cinemachine;

public class FreeLookSwitcher : MonoBehaviour
{
	private CinemachineFreeLook cinemachineFreeLook;

	private void Start()
	{
		cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("1")) {
			cinemachineFreeLook.Priority = 99;
		}
		
		if (Input.GetKeyDown("2")) {
			cinemachineFreeLook.Priority = 0;
		}
		
	}
}
