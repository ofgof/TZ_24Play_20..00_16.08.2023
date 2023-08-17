using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _halfTrackWeidth;
    [SerializeField] private float _trackLength;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;

    [SerializeField] private GameObject _cubeHolder;
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _speedVFX;

    [SerializeField] private AnimatorController _animatorController;

    private Sequence _sideSequence;
    public void Init()
    {
        _speedVFX.SetActive(false);

        InputController.OnSwipe += MoveSide;
        Collector.OnCollect += CollectAnimation;
        GameManager.OnGameStart += StartMove;
        GameManager.OnGameEnd += StopMove;
    }
    private void OnDestroy()
    {
        InputController.OnSwipe -= MoveSide;
        Collector.OnCollect -= CollectAnimation;
        GameManager.OnGameStart -= StartMove;
        GameManager.OnGameEnd -= StopMove;

    }
    private void StartMove()
    {
        _speedVFX.SetActive(true);
        MoveForward();
    }
    private void MoveForward()
    {
        float duration = 1f;
        var targetPosition = transform.position + _forwardSpeed * Vector3.forward;
        transform.DOMoveZ(targetPosition.z, duration).SetEase(Ease.Linear).OnComplete(MoveForward);
    }
    private void StopMove()
    {
        transform.DOKill();
    }
    private void MoveSide(float direction)
    {
        _sideSequence.Kill();
        _sideSequence = DOTween.Sequence();
        var position = transform.position;
        var deltaPosition = direction * _sideSpeed * Time.deltaTime * Vector3.right;
        var targetPosition = position + deltaPosition;

        if(Mathf.Abs(targetPosition.x) < _halfTrackWeidth)
        {
            _sideSequence.Append(transform.DOMoveX(targetPosition.x, Time.deltaTime));
        }
        else
        {
            position.x = Mathf.Sign(position.x) * _halfTrackWeidth;
            transform.position = position;
        }
    }

    private void CollectAnimation(GameObject newCube)
    {
        Debug.Log("CollectAnimation");
        float cubeSide = 1f;
        float duration = GameManager.Instance.GlobalConstants.CubeCollectionDuration;
        newCube.SetActive(false);

        _animatorController.Jump();
        _character.transform.DOMoveY(_character.transform.position.y + cubeSide, duration).SetEase(Ease.Linear).OnComplete(() =>
        {
            newCube.transform.parent = _cubeHolder.transform;
            var targetPosition = cubeSide * (_cubeHolder.transform.childCount - 1) * Vector3.up;
            newCube.transform.localPosition = targetPosition;
            newCube.SetActive(true);
            GameManager.Instance.VFXHolder.SpawnVFX(VFXType.CollectVFX, newCube.transform.position);
            //var collect = Instantiate(GameManager.Instance.VFXHolder.GetVFX(VFXType.CollectVFX));
            //collect.transform.position = newCube.transform.position;
            var plusOne = GameManager.Instance.VFXHolder.SpawnVFX(VFXType.CollectPlusOne, _character.transform.position);
            //Instantiate(GameManager.Instance.VFXHolder.GetVFX(VFXType.CollectPlusOne));
            //plusOne.transform.position = _character.transform.position;
            plusOne.transform.DOMoveY(_character.transform.position.y + 1.5f, duration).SetEase(Ease.Linear);
        });
    }
}
