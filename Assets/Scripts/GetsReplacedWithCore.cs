using UnityEngine;

public class GetsReplacedWithCore : MonoBehaviour {

    public GameObject ToCreate;

	void Awake () {
		ReplacedWithCore ();
	}

	void ReplacedWithCore(){
        Instantiate(ToCreate, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}
