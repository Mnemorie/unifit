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
		Application.LoadLevel (this.currentLevel); 
	}

	private void RestartLevel(){
		Application.LoadLevel (this.currentLevel);
	}


	public void Lose(){
		RestartLevel ();

	}

	public void EndLevel(){
		LoadNextLevel ();

	}
}
