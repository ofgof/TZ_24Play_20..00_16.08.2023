using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static Action<float> OnSwipe;

    [SerializeField] float _maxMagnitude = 200f;

    private float _touchPositionX;
    private bool _isGameStarted = false;
    private Coroutine _swipeCoroutine;
    private void Start()
    {
        GameManager.OnGameStart += StartInputControll;
        GameManager.OnGameEnd += StopInputControll;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStart -= StartInputControll;
        GameManager.OnGameEnd -= StopInputControll;
    }
    private void Update()
    {
        //CheckSwipe();
        if (!_isGameStarted && Input.GetMouseButtonDown(0))
        {
            _isGameStarted = true;
            GameManager.OnGameStart?.Invoke();
        }
    }
    private void StartInputControll()
    {
        _swipeCoroutine = StartCoroutine(CheckSwipe());
    }
    private void StopInputControll()
    {
        StopCoroutine(_swipeCoroutine);
        _isGameStarted = false;
    }
    private IEnumerator CheckSwipe()
    {
        while (true)
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
                OnSwipe?.Invoke(magnitude);
            }
            yield return null;
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
