using UnityEngine;
using System.Collections;

public class PistonMotion : MonoBehaviour {

	public Vector3 startPoint;
	public Vector3 endPoint;

	public AnimationCurve returnCurve;
	public AnimationCurve pushCurve;

	public bool pushing;
	public float Speed;

	private float currentValue;
	public float CurrentValue{
		get {return currentValue;}
		set {currentValue =	(value < 0f) ? 0 :
				 				(value >= 1f ? 1f: value);
			if (currentValue >= 1f)
				pushing = false;
			}
	}
	public float recoilFactor;
	//public Rigidbody ApplyRecoilTo;
	//public Transform AtTransform;

	// Use this for initialization
	void Start () {
	
	}

	public Vector3 UnclampedLerp(Vector3 start, Vector3 end, float ratio){
		Vector3 diff = end - start;
		Vector3 result = start + diff * ratio;
		return result;
	}


 	public void SetPushing(){
		this.pushing = true;
	}

	private void Recoil(Rigidbody ApplyForceTo, Vector3 AtPosition){	
		ApplyForceTo.GetComponent<Rigidbody>().AddForceAtPosition(-this.transform.up * recoilFactor , AtPosition);
	}

	private void Push(){
		this.transform.localPosition = UnclampedLerp(startPoint, endPoint, pushCurve.Evaluate(CurrentValue));
		CurrentValue = CurrentValue + Speed * Time.deltaTime;
		//Recoil(this.ApplyRecoilTo, this.AtTransform.localPosition);
		Recoil(this.GetComponentInParent<Rigidbody>(), this.transform.parent.position);

	}

	private void Return(){
		this.transform.localPosition = UnclampedLerp(startPoint, endPoint, returnCurve.Evaluate(CurrentValue));
		CurrentValue = CurrentValue - Speed * Time.deltaTime;
	}

	void Update () {
		if(pushing)  
			Push();
		else
			Return();		
	}
}
