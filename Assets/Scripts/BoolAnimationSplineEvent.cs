using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAnimationSplineEvent : SplineEvent
{
    public Animator animator;
    public string parameterName;
    public bool newValue;

    public override void TriggerEvent()
    {
        animator.SetBool(parameterName, newValue);
        base.TriggerEvent();
    }
}
