using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battlehub.SplineEditor;

public class SpeedSplineEvent : SplineEvent
{
    public SplineFollow splineFollow;
    public float newSpeed;

    public override void TriggerEvent()
    {
        print("Speed Event Triggered!");
        splineFollow.Speed = newSpeed;
        base.TriggerEvent();
    }
}
