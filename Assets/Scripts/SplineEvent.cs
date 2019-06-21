using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class SplineEvent : MonoBehaviour
{
    public Transform eventTrigger;
    bool arrived;

    protected virtual void Update()
    {
        if (eventTrigger)
        {
            float distanceToTrigger = MathUtilities.CheckDistance(transform.position, eventTrigger.position);

            if (!arrived && distanceToTrigger <= .1f)
            {
                arrived = true;
                TriggerEvent();
            }
        }
    }

    public virtual void TriggerEvent() { }
}
