using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //game events
    public static Action OnGameStart;
    public static Action OnGameRestart;
    public static Action OnGameEnd;

    public static Action OnCrossChunk;

    [SerializeField] private GlobalConstants _globalConstants;
    [SerializeField] private VFXHolder _VFXHolder;

    [SerializeField] private ViewController _viewController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LevelController _levelController;

    public GlobalConstants GlobalConstants => _globalConstants;
    public VFXHolder VFXHolder => _VFXHolder;

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
        _VFXHolder.Init();
        _viewController.Init();
        _playerController.Init();
        _levelController.Init();
    }
}
