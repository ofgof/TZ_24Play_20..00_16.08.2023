using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ViewController _viewController;
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        _viewController.Init();
        _playerController.Init();
    }
}
