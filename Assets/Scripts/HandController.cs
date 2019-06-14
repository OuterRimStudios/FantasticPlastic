using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public XRNode device;
    public float interactionRadius;
    public LayerMask interactionLayer;

    [Space]
    public float frequency = 1;
    public float amplitude = 1;

    private void Update()
    {
        OVRInput.Update();
        transform.position = transform.TransformDirection (InputTracking.GetLocalPosition(device));
        transform.rotation = InputTracking.GetLocalRotation(device);
        InputDevice controller = InputDevices.GetDeviceAtXRNode(device);

        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);

        if (interactables.Length > 0)
        {
            controller.SendHapticImpulse(0, 1000);

            Interaction interaction = interactables[0].GetComponent<Interaction>();

            if (interaction)
                interaction.Interact();

            print("Triggered");
        }
        else
            controller.SendHapticImpulse(0, 0);
    }
}
