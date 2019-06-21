using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battlehub.SplineEditor;

public class SpeedSplineEvent : SplineEvent
{
    public SplineFollow splineFollow;
    public float newSpeed;
    public float acceleration;

    public override void TriggerEvent()
    {
        StartCoroutine(ChangeSpeed());
        base.TriggerEvent();
    }

    IEnumerator ChangeSpeed()
    {
        yield return new WaitUntil(() => ChangingSpeed());
        splineFollow.Speed = newSpeed;
    }

    bool ChangingSpeed()
    {
        splineFollow.Speed = Mathf.Lerp(splineFollow.Speed, newSpeed, acceleration * Time.deltaTime);
        return Mathf.Abs(splineFollow.Speed - newSpeed) <= .01f;
    }
}
