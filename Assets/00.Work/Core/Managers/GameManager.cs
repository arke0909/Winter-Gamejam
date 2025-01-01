using GGMPool;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private PoolManagerSO _poolManagerSO;

    private Player player;
    public Player Player => player;

    public PoolManagerSO PoolManagerSO => _poolManagerSO;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();

    }
}
