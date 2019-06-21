using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class ScaleSplineEvent : SplineEvent
{
    public Vector3 newScale;
    
    public Transform endPoint;

    public GameObject effect;
    public AudioClip sound;

    public bool spawnAtEndPoint;

    AudioSource source;
    float startingScale;
    float maxDistance;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = sound;
    }

    public override void TriggerEvent()
    {
        maxDistance = MathUtilities.CheckDistance(eventTrigger.position, endPoint.position);
        startingScale = transform.localScale.x;

        if(!spawnAtEndPoint)
        {
            Instantiate(effect, eventTrigger.position, eventTrigger.localRotation);
            source.Play();
        }

        StartCoroutine(ChangeScale());
        base.TriggerEvent();
    }

    IEnumerator ChangeScale()
    {
        yield return new WaitUntil(() => ChangingScale());
        transform.localScale = newScale;

        if(spawnAtEndPoint)
        {
            Instantiate(effect, endPoint.position, Quaternion.identity);
            source.Play();
        }
    }

    bool ChangingScale()
    {
        float currentDistance = MathUtilities.CheckDistance(transform.position, endPoint.position);
        float scale;
        
        scale = Mathf.Abs(MathUtilities.MapValue(0, maxDistance, startingScale, newScale.x,  currentDistance));

        scale = Mathf.Clamp(scale, startingScale, newScale.x);
        print("Distance: " + maxDistance);
        print("Current Distance: " + currentDistance);
        print("Scale: " + scale);
         
        transform.localScale = new Vector3(scale, scale, scale);
        return currentDistance <= .2f;
    }
}
