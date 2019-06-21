using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedAudioTiming : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float minDelay = 2.0f;
    public float maxDelay = 5.0f;

    IEnumerator Start()
    {
        for (;;)
        {
            if (source.isPlaying) yield break;
            
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            source.Play();
        }
    }
}
