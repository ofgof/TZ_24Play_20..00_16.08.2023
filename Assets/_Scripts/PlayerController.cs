using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _halfTrackWeidth;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    public void Init()
    {
        InputController.OnSwipe += MoveSide;
    }
    private void OnDestroy()
    {
        InputController.OnSwipe -= MoveSide;
    }
    private void Update()
    {
        MoveForward();
    }
    private void MoveForward()
    {
        var targetPosition = transform.position + _forwardSpeed * Time.deltaTime * transform.forward;
        transform.DOMoveZ(targetPosition.z, Time.deltaTime);
    }
    private void MoveSide(float direction)
    {
        var position = transform.position;
        var deltaPosition = direction * _sideSpeed * Time.deltaTime * gameObject.transform.right;
        var targetPosition = position + deltaPosition;

        if(Mathf.Abs(targetPosition.x) < _halfTrackWeidth)
        {
            transform.DOMoveX(targetPosition.x, Time.deltaTime);
        }
        else
        {
            position.x = Mathf.Sign(position.x) * _halfTrackWeidth;
            transform.position = position;
        }

    }
}
