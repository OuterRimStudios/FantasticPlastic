using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{
    public float speed;
    public float force;
    public float acceleration;
    public float deceleration;

    float constantSpeed;

    bool accelerating;

    private void Start()
    {
        constantSpeed = speed;
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if(!accelerating)
            speed = Mathf.MoveTowards(speed, constantSpeed, deceleration * Time.deltaTime);
    }

    public void Accelerate()
    {
        StartCoroutine(Aceelerating());
    }

    IEnumerator Aceelerating()
    {
        accelerating = true;
        yield return new WaitUntil(() => Accelerated());
        speed = force;
        accelerating = false;
    }

    bool Accelerated()
    {
        speed = Mathf.MoveTowards(speed, force, acceleration * Time.deltaTime);
        return speed >= force;
    }
}
