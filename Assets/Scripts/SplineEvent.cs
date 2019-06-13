using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineEvent : MonoBehaviour
{
    public List<Transform> eventTriggers;

    int currentEventTrigger;
    bool arrived;

    void Update()
    {
        if (eventTriggers.Count > 0 && currentEventTrigger < eventTriggers.Count)
        {
            float distanceToTrigger = Vector3.Distance(transform.position, eventTriggers[currentEventTrigger].position);

            if (!arrived && distanceToTrigger <= .1f)
            {
                arrived = true;
                distanceToTrigger++;

                TriggerEvent();
            }
        }
    }

    public virtual void TriggerEvent()
    {
        arrived = false;
    }
}
