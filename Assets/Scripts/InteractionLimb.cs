using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLimb : Interaction
{
    public Interaction[] mainInteractions;

    public override void Interact()
    {
        foreach (Interaction interaction in mainInteractions)
            interaction.Interact();
    }
}
