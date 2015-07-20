using UnityEngine;
using System.Collections;

public class StartOnKey : MonoBehaviour 
{
	public KeyCode startKey;
	public GameController gameController;

	void Update ()
    {
		if (Input.GetKeyDown (startKey)) 
        {
            gameController.EndLevel();
		}
	}
}
