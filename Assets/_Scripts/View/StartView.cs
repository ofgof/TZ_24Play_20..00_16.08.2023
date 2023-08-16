using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartView : View
{
    [SerializeField] private Hand _hand;

    public override void Init()
    {
        _hand.Inti();
        Open();
    }
    public override void Open()
    {
        base.Open();
        _hand.PlayAnimation();
    }
    public override void Close()
    {
        base.Close();
    }













    [Serializable]
    private class Hand
    {
        [SerializeField] private GameObject _handObject;

        [SerializeField] private float _maxScale;
        [SerializeField] private float _animationDuration;

        [SerializeField] private float _moveMagnitude;

        private Vector3 _basePosition;
        private Sequence _animation;
        public void Inti()
        {
            _basePosition = _handObject.transform.position;
            _animation = HandAnimation();

        }
        public void PlayAnimation()
        {
            _animation.Restart();
            //_animation.Play();
        }
        private Sequence HandAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            Sequence scaleSequence = DOTween.Sequence();
            Sequence moveSequence = DOTween.Sequence();
            
            float scaleDurration = _animationDuration * 0.4f;
            float moveDurration = _animationDuration * 0.5f;
            float waitDurration = _animationDuration * 0.3f;

            var transform = _handObject.transform;

            scaleSequence.Append(transform.DOScale(Vector3.one * _maxScale, 0f));
            scaleSequence.Append(transform.DOScale(Vector3.one, scaleDurration).SetEase(Ease.Linear));

            float center = _basePosition.x;
            float left = center - _moveMagnitude;
            float right = center + _moveMagnitude;

            moveSequence.Append(transform.DOMoveX(left, moveDurration).SetEase(Ease.Linear));
            moveSequence.Append(transform.DOMoveX(center, moveDurration).SetEase(Ease.Linear));
            moveSequence.Append(transform.DOMoveX(right, moveDurration).SetEase(Ease.Linear));
            moveSequence.Append(transform.DOMoveX(center, moveDurration).SetEase(Ease.Linear));

            moveSequence.Append(transform.DOMoveX(center, waitDurration).SetEase(Ease.Linear));

            moveSequence.SetLoops(-1, LoopType.Restart);

            sequence.Append(scaleSequence);
            sequence.Append(moveSequence);

            if (sequence.IsPlaying())
                sequence.TogglePause();

            return sequence;

        }
    }
}
