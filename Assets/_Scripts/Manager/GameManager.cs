using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //game events
    public static Action OnGameStart;
    public static Action OnGameRestart;
    public static Action OnGameEnd;

    [SerializeField] private GlobalConstants _globalConstants;

    [SerializeField] private ViewController _viewController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LevelController _levelController;

    private bool _isGame = false;

    public GlobalConstants GlobalConstants => _globalConstants;

    public bool IsGame => _isGame;

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
        _levelController.Init();
    }
}
