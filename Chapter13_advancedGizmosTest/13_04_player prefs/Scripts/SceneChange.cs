using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
	const int MAIN_MENU = 0;
	const int GAME_PLAYING = 1;
	const int GAME_WON = 2;
	const int GAME_LOST = 3;
	
	public void GotoScene(int sceneNumber){
		Application.LoadLevel(sceneNumber);
	}
}
