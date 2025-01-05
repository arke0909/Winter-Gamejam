using GGMPool;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private PoolManagerSO _poolManagerSO;
    [SerializeField] private CinemachineCamera _playerCam;

    private Player player;

    public Player Player => player;

    public PoolManagerSO PoolManagerSO => _poolManagerSO;
    public CinemachineCamera PlayerCam => _playerCam;

    public ClearManager ClearManager { get; private set; }

    public UnityEvent OnClearEvent;
    public UnityEvent OnFailEvent;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();

        ClearManager = GetComponentInChildren<ClearManager>();
    }
}
