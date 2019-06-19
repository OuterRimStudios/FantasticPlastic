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
        transform.position = InputTracking.GetLocalPosition(device);
        transform.rotation = InputTracking.GetLocalRotation(device);
        InputDevice controller = InputDevices.GetDeviceAtXRNode(device);

        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);

        if (interactables.Length > 0)
        {
            controller.SendHapticImpulse(0, amplitude, frequency);

            Interaction interaction = interactables[0].GetComponent<Interaction>();

            if (interaction)
                interaction.Interact();
        }
        else
            controller.SendHapticImpulse(0, 0);

        List<InputDevice> controllers = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(device, controllers);

        if (controllers.Count <= 0) return;

        bool triggerValue;
        if(controllers[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            print(device +  " Trigger Pressed");
        }
    }
}