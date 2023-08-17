using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailView : View
{
    [SerializeField] private GameObject _failText;
    [SerializeField] private Button _tryAgainButton;

    public override void Init()
    {
        IntiButtons();
    }

    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base.Close();
    }

    private void IntiButtons()
    {
        _tryAgainButton.onClick.AddListener(() =>
        {
            Debug.Log("Reload scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

}
