using UnityEngine;
using System.Collections;

public class StartOnKey : MonoBehaviour 
{
	public KeyCode startKey;
	public GameController gameController;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Debug.Log("Deleting saved settings");
            PlayerPrefs.DeleteAll();
        }

		if (Input.GetKeyDown (startKey)) 
        {
            if (!PlayerPrefs.HasKey("p1ControllerType"))
            {
                Application.LoadLevel(1);
            }
            else
            {
                Application.LoadLevel(2);
            }
		}
	}
}
