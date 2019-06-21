using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCamera : MonoBehaviour
{
    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        transform.localPosition = mainCam.transform.position;
        transform.localRotation = mainCam.transform.rotation;
    }
}
