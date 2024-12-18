using GGMPool;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private PoolManagerSO _poolManager;
    [SerializeField] private Transform _firePos;

    private Player _player;
    private InputReader _inputReader;

    private bool _canFire = true;

    [field: SerializeField]
    public float BaseReloadTime { get; private set; } = 2;

    private float currentLoadTime;

    [field: SerializeField]
    public float BaseAttack { get; private set; } = 10;

    private float currentAttack;

    public void Initialize(Player player)
    {
        _player = player;

        _inputReader = _player.GetCompo<InputReader>();

        currentLoadTime = BaseReloadTime;

        _inputReader.OnAttackEvent += HandleSAttackEvent;
    }

    private void Update()
    {
        RotateGun();
    }

    private void RotateGun()
    {
        Vector2 mousePos = (Vector3)_inputReader.MousePos - transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        GunFlip(angle);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void GunFlip(float angle)
    {
        float scaleY = angle > 90 || angle < -90 ? -1 : 1;

        transform.localScale = new Vector3(1, scaleY, 1);
    }

    private void HandleSAttackEvent()
    {
        if (_canFire)
        {
            Fire();
            Reload();
        }
    }

    private void Fire()
    {
        Debug.Log("Fire!!");
        Bullet bullet = _poolManager.Pop(_poolType) as Bullet;

        bullet.Initialize(_firePos.position, _firePos.right, currentAttack, 0);
    }

    private void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        _canFire = false;
        yield return new WaitForSeconds(BaseReloadTime);
        _canFire = true;
    }

    private void OnDisable()
    {
        _inputReader.OnAttackEvent -= HandleSAttackEvent;
    }
}
