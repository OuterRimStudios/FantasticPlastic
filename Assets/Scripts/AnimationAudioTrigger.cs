using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioTrigger : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    [Range(0, 1)]
    public float volume = 0.5f;

    public void PlayClip()
    {
        source.PlayOneShot(clip, volume);
    }
}