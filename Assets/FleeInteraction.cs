using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battlehub.SplineEditor;

public class FleeInteraction : Interaction
{
    public float fleeLength;

    [Space]
    public SplineFollow splineFollow;
    public float newSpeed;
    public float acceleration;

    [Space]
    public Animator animator;
    public string parameterName;
    public bool newValue;

    bool interacted;

    float oldSpeed;

    public override void Interact()
    {
        if(!interacted)
        {
            interacted = true;
            oldSpeed = splineFollow.Speed;
            animator.SetBool(parameterName, newValue);
            StartCoroutine(ChangeSpeed(newSpeed));

            StartCoroutine(Flee());
        }
    }

    IEnumerator Flee()
    {
        yield return new WaitForSeconds(fleeLength);
        StartCoroutine(ChangeSpeed(oldSpeed));
        animator.SetBool(parameterName, !newValue);
    }

    IEnumerator ChangeSpeed(float speed)
    {
        yield return new WaitUntil(() => ChangingSpeed(speed));
        splineFollow.Speed = speed;
    }

    bool ChangingSpeed(float speed)
    {
        splineFollow.Speed = Mathf.Lerp(splineFollow.Speed, newSpeed, acceleration * Time.deltaTime);
        return Mathf.Abs(splineFollow.Speed - speed) <= .01f;
    }
}
