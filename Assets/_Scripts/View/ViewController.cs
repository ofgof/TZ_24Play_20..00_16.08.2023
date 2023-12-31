using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] StartView _startView;
    [SerializeField] FailView _failView;

    public void Init()
    {
        _startView.Init();
        _failView.Init();

        OpenStartView();

        GameManager.OnGameStart += CloseAllView;
        GameManager.OnGameEnd += OpenFailView;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStart -= CloseAllView;
        GameManager.OnGameEnd -= OpenFailView;

    }
    private void OpenStartView()
    {
        CloseAllView();
        _startView.Open();
    }
    private void OpenFailView()
    {
        CloseAllView();
        _failView.Open();
    }
    private void CloseAllView()
    {
        _startView.Close();
        _failView.Close();
    }
}
