using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineEvent : MonoBehaviour
{
    public Transform eventTrigger;
    bool arrived;

    void Update()
    {
        if (eventTrigger)
        {
            float distanceToTrigger = Vector3.Distance(transform.position, eventTrigger.position);

            if (!arrived && distanceToTrigger <= .1f)
            {
                arrived = true;
                TriggerEvent();
            }
        }
    }

    public virtual void TriggerEvent() { }
}
