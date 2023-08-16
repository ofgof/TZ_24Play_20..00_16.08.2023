using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static Action<float> OnSwipe;

    private float _touchPositionX;
    private void Update()
    {
        CheckSwipe();
    }
    private void CheckSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchPositionX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            var currentPositionX = Input.mousePosition.x;
            var magnitude = currentPositionX - _touchPositionX;
            _touchPositionX = currentPositionX;

            Debug.Log("[InputController] magnitude = " + magnitude);
            OnSwipe?.Invoke(magnitude);
        }
    }
}
