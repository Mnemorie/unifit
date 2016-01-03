using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubGoal : MonoBehaviour 
{
    public ShapeEndsLevel RootGoal;
    public List<Collider> Heads;
    private Animator Animator;

    private Collider Collider;

    public bool IsValid()
    {
        return Heads.Any(head => head.bounds.Intersects(Collider.bounds));
    }

    void Start()
    {
        Collider = GetComponent<Collider>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Animator)
        {
            Animator.SetBool("valid", IsValid());
            Animator.SetBool("final", RootGoal.IsValid());
        }
    }
}
