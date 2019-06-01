using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class Caustics : MonoBehaviour {
    [SerializeField] List<Texture2D> cookies;
    [SerializeField] float delayTime = 0.01f;
    Light source;

    private IEnumerator Start () {
        source = GetComponent<Light> ();

        for (int i = 0; i < cookies.Count; i++) {
            source.cookie = cookies[i];
            if (i == cookies.Count - 1)
                i = 0;
            yield return new WaitForSeconds (delayTime);
        }
    }
}