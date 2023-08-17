using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public static Action<GameObject> OnCollect;

    private void OnTriggerEnter(Collider other)
    {
        var collectableObject = other.gameObject.GetComponent<ICollectable>();
        collectableObject?.Collect();
    }
}
