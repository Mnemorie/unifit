using UnityEngine;

public class GetsReplacedWithCore : MonoBehaviour {

    public GameObject ToCreate;

	void Start () {
		ReplacedWithCore ();
	}

	void ReplacedWithCore(){
        GameObject thing = Instantiate(ToCreate, this.transform.position, Quaternion.identity) as GameObject;
		Camera.main.GetComponent<FollowsObject> ().followThis = thing;
		Destroy (this.gameObject);
	}
}
