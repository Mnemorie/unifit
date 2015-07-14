using UnityEngine;
using System.Collections;

public class EndsLevel : MonoBehaviour 
{
	public GameController gameController;
	public float TimeRequiredToWin;
	public float RotationSpeed ;

	private GameObject intruder;
	public float IntruderEnteredAtTime;

	public float TimeSpentInside;

	// Use this for initialization
	void Start () 
    {
        gameController = FindObjectOfType<GameController>();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.GetComponent<CanEndLevel>() != null) {
			this.intruder = collider.gameObject;
			IntruderEnteredAtTime =Time.time;
		}
	}

	void OnTriggerLeave(){
		this.intruder = null;
		this.TimeSpentInside = 0f;
		ResetDisplay ();
	}

	void OnTriggerExit(){
		this.intruder = null;
		this.TimeSpentInside = 0f;
		ResetDisplay ();
	}

	void OnTriggerStay(Collider collider){
		if (collider.gameObject != this.intruder) {
			return;
		}

		ChangeDisplayWhenInside ();

		this.TimeSpentInside = Time.time - IntruderEnteredAtTime;

		if (this.TimeSpentInside > TimeRequiredToWin)
			EndLevel ();
	}


	void ChangeDisplayWhenInside(){
		this.transform.RotateAround (this.transform.position, Vector3.left, RotationSpeed * Time.deltaTime);
	}
	void ResetDisplay(){
		this.transform.localRotation = Quaternion.identity;
	}


	void EndLevel(){
		Debug.Log ("Level Ended");
		gameController.EndLevel ();
	}
	// Update is called once per frame
	void Update () {


	}

    public GUISkin Skin;
    public Color TimerColor;

    public int TimerVerticalOffset = 100;

    void OnGUI()
    {
        Vector2 screenPos = GUIUtility.ScreenToGUIPoint(Camera.main.WorldToScreenPoint(transform.position));
        Rect labelRect = new Rect(screenPos.x - 25, Screen.height - screenPos.y - TimerVerticalOffset, 50, 30);

        GUI.skin = Skin;

        string timer = Mathf.FloorToInt(Time.timeSinceLevelLoad).ToString();
        GUIHelper.DrawOutline(labelRect, timer, 2);
        GUI.color = TimerColor;
        GUI.Label(labelRect, timer);
    }
}
