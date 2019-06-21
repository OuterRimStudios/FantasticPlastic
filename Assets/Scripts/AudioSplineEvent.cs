using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSplineEvent : SplineEvent
{
    public AudioSource source;
    public AudioClip clip;

    public override void TriggerEvent()
    {
        base.TriggerEvent();
        print(gameObject.name + " audio event triggered");
        source.PlayOneShot(clip);
    }
}
