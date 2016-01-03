using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ShapeEndsLevel : EndsLevel
{
    public override bool IsValid()
    {
        return SubGoals.All(subgoal => subgoal.IsValid());
    }

    protected override void AnimateValid()
    {
        base.AnimateValid();
    }

    private List<SubGoal> SubGoals;
    private List<Collider> Heads;

    protected override void Start ()
	{
	    base.Start();

        SubGoals = new List<SubGoal>(GetComponentsInChildren<SubGoal>());
        Heads = new List<Collider>(Core.GetComponentsInChildren<Collider>());

        var subGoals = GetComponentsInChildren<SubGoal>();
        foreach (var subgoal in subGoals)
        {
            subgoal.Heads = Heads;
            subgoal.RootGoal = this;
        }
    }
}
