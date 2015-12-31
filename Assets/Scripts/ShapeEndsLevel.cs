using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ShapeEndsLevel : EndsLevel
{
    protected override bool IsValid()
    {
        return Heads.All(head => Colliders.Any(collider => collider.bounds.Intersects(head.bounds)));
    }

    protected override void AnimateValid()
    {
        base.AnimateValid();
    }

    private List<Collider> Colliders;
    private List<Collider> Heads;

    protected override void Start ()
	{
	    base.Start();

        Colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        Heads = new List<Collider>(Core.GetComponentsInChildren<Collider>());
    }
}
