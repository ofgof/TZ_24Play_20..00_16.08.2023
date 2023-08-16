using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static Action<float> OnSwipe;

    [SerializeField] float _maxMagnitude = 200f;

    private float _touchPositionX;
    private void Update()
    {
        CheckSwipe();
    }
    private void CheckSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchPositionX = GetTouchPosition().x;
        }
        if (Input.GetMouseButton(0))
        {
            var currentPositionX = GetTouchPosition().x;
            var magnitude = currentPositionX - _touchPositionX;
            _touchPositionX = currentPositionX;
            if (Mathf.Abs(magnitude) > _maxMagnitude)
            {
                magnitude = _maxMagnitude * Mathf.Sign(magnitude);
            }
            Debug.Log("[InputController] magnitude = " + magnitude);
            OnSwipe?.Invoke(magnitude);
        }
    }

    private Vector2 GetTouchPosition()
    {
#if UNITY_EDITOR
        return Input.mousePosition;
#else
        return Input.touches[0].position;
#endif
    }
}
