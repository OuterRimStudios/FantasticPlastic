using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredCamera : MonoBehaviour
{
    void Update()
    {
        if(transform.parent)
        {
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;
        }
    }
}
