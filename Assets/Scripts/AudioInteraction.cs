using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    AudioSource source;

    bool interacted;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if(!interacted)
        {
            interacted = true;
            source.Play();
        }
    }
}
