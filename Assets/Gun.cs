using GGMPool;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private CinemachineCamera _cinemachineCamera;

    [SerializeField] private Transform _firePos;
    [SerializeField] private Transform _cameraFollowTrm;

    [SerializeField] private PoolManagerSO poolManager;
    [SerializeField] private PoolTypeSO poolType;

    public UnityEvent OnFireEvent;

    private Player _player;

    private void Awake()
    {
        _cinemachineCamera.Follow = _cameraFollowTrm;
    }

    public void Initialize(Player player)
    {
        _player = player;

        _player.InputCompo.OnAttackEvent += Fire;
    }

    private void Fire()
    {
        Bullet bullet = poolManager.Pop(poolType) as Bullet;

        bullet.Initialize(_firePos.position, _firePos.right);

        _player.InputCompo.OnAttackEvent -= Fire;

        _cinemachineCamera.Follow = bullet.transform;

        OnFireEvent?.Invoke();
    }
}
