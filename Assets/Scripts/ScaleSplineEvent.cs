using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class ScaleSplineEvent : SplineEvent
{
    public float speed;
    public Vector3 newScale;
    public Transform effectTriggerPoint;

    public GameObject effect;
    public AudioClip[] sounds;

    AudioSource source;
    bool triggered;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public override void TriggerEvent()
    {
        if(sounds.Length > 0)
            source.clip = CollectionUtilities.GetRandomItem(sounds);

        StartCoroutine(ChangeScale());
        base.TriggerEvent();
    }

    protected override void Update()
    {
        base.Update();

        if(!triggered && MathUtilities.CheckDistance(transform.position, effectTriggerPoint.position) <= .1f)
        {
            triggered = true;
            Instantiate(effect, eventTrigger.position, eventTrigger.localRotation);
            if (sounds.Length > 0)
                source.Play();
        }
    }

    IEnumerator ChangeScale()
    {
        yield return new WaitUntil(() => ChangingScale());
        transform.localScale = newScale;
    }

    bool ChangingScale()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, newScale, speed * Time.deltaTime);
        return MathUtilities.CheckDistance(transform.localScale, newScale) <= 0f;
    }
}
