using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSeconds : MonoBehaviour
{
    public GameObject objectToEnable;
    public float enableAfter;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(enableAfter);
        objectToEnable.SetActive(true);
    }
}
