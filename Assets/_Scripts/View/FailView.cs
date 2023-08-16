using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailView : View
{
    [SerializeField] private GameObject _failText;
    [SerializeField] private Button _tryAgainButton;

    public override void Init()
    {

    }

    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base .Close();
    }

    private void IntiButtons()
    {
        _tryAgainButton.onClick.AddListener(() =>
        {

        });
    }

}
