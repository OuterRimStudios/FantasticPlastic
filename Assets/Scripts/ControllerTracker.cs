using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTracker : MonoBehaviour
{
    public enum Hand
    {
        Left,
        Right
    };

    public Hand hand;

    private void Update()
    {
        OVRInput.Update();
        transform.localPosition = hand == Hand.Left ? OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch) : OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = hand == Hand.Left ? OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch) : OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
    }
}
