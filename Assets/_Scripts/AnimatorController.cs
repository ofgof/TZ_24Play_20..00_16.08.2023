using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _jumpVariableName = "Jump";

    public void Jump()
    {
        SetJump(true);
    }

    private void SetJump(bool jump)
    {
        _animator.SetBool(_jumpVariableName, jump);
    }
}
