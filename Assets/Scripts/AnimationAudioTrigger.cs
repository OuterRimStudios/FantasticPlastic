using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioTrigger : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    public void PlayClip()
    {
        source.PlayOneShot(clip);
    }
}