#pragma strict

var farColor : Color;
var midColor : Color;
var nearColor : Color;
@Range(0,1)
var midPoint : float = 0.5;
var objects : GameObject[];

function Update () {
	for (var i = 0; i < objects.length; i++) {
		
		var couleur : Color;
		var length : float = objects.length-1;
		
		if(i <= length * midPoint)
			couleur = Color.Lerp(farColor,midColor,
				i/(length*midPoint));
		else
			couleur = Color.Lerp(midColor,nearColor,
				i/(length*midPoint)-midPoint);
		
		objects[i].GetComponent.<Renderer>().material.SetColor("_Color",couleur);
	};
}