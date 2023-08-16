using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
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
        _characterController.Move(_forwardSpeed * Time.deltaTime * gameObject.transform.forward);
    }
    private void MoveSide(float direction)
    {
        _characterController.Move(direction * _sideSpeed * Time.deltaTime * gameObject.transform.right);
    }
}
