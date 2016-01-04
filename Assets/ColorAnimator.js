#pragma strict

var RangeTotal : float = 0.09;
var RangeMin : float = 0.15;
var RangeMax : float = 0.3;
var DistanceFalloff : float = 0.1;


function Update () {

	//GetComponent.<Renderer>().material.SetFloat("_Range", RangeTotal);
	//GetComponent.<Renderer>().material.SetFloat("_RangeMin", RangeMin);
	//GetComponent.<Renderer>().material.SetFloat("_RangeMax", RangeMax);
	GetComponent.<Renderer>().material.SetFloat("_DistanceFalloff", DistanceFalloff);

}