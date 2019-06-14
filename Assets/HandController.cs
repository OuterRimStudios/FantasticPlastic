using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public OVRInput.Controller device;
    public float interactionRadius;
    public LayerMask interactionLayer;

    [Space]
    public float frequency = 1;
    public float amplitude = 1;

    private void Update()
    {
        OVRInput.Update();
        transform.localPosition = OVRInput.GetLocalControllerPosition(device);
        transform.localRotation = OVRInput.GetLocalControllerRotation(device);

        if (Physics.CheckSphere(transform.localPosition, interactionRadius, interactionLayer))
            OVRInput.SetControllerVibration(frequency, amplitude, device);
        else
            OVRInput.SetControllerVibration(0, 0, device);
    }
}
