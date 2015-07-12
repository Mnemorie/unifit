using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int currentLevel;

	void Start(){
		currentLevel = 0;
	}

	public void StartGame(){
		LoadNextLevel ();
	}

	private void LoadNextLevel(){
		this.currentLevel ++;
		Application.LoadLevel (Application.loadedLevel +1); 
	}

	private void RestartLevel(){
		Application.LoadLevel (Application.loadedLevel);
	}


	public void Lose(){
		RestartLevel ();

	}

	public void EndLevel(){
		LoadNextLevel ();

	}
}
