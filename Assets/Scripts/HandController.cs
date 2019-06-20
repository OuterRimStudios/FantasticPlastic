using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public XRNode device;
    public float interactionRadius;
    public LayerMask interactionLayer;
    public LayerMask pickUpLayer;

    [Space]
    public float frequency = 1;
    public float amplitude = 1;

    Rigidbody heldObject;

    private void Update()
    {
        OVRInput.Update();
        transform.position = InputTracking.GetLocalPosition(device);
        transform.rotation = InputTracking.GetLocalRotation(device);
        InputDevice controller = InputDevices.GetDeviceAtXRNode(device);

        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);

        if (interactables.Length > 0)
        {
            IgnoreVibration ignoreVibration = interactables[0].GetComponent<IgnoreVibration>();

            if(ignoreVibration == null)
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius, pickUpLayer);

            if(colliders.Length > 0)
            {
                heldObject = colliders[0].attachedRigidbody;
                heldObject.useGravity = false;
                heldObject.isKinematic = true;

                heldObject.GetComponent<UpdatePosition>().enabled = true;

                heldObject.transform.parent = transform;
            }
        }
        else
        {
            if(heldObject)
            {
                heldObject.GetComponent<UpdatePosition>().enabled = false;
                heldObject.transform.parent = null;
                heldObject.isKinematic = false;
                heldObject.useGravity = true;
                heldObject = null;
            }
        }
    }
}