using GGMPool;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private float _radius = 1;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed = 500;

    private Rigidbody2D _rigid;
    private TrailRenderer _trailRenderer;
    private Collider2D _enemyCollider = null;
    private Pool _pool;

    private bool _isDead = false;
    private Vector2 moveDir;

    public PoolTypeSO PoolType => poolType;

    public GameObject GameObject => gameObject;

    public UnityEvent OnDeadEvent;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    public void Initialize(Vector3 position, Vector2 dir)
    {
        transform.position = position;

        _rigid.linearVelocity = dir.normalized * speed;

        transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
    }

    private void FixedUpdate()
    {
        if (_isDead) return;

        _enemyCollider = Physics2D.OverlapCircle(transform.position, _radius, _whatIsEnemy);

        if (_enemyCollider == null) return;

        Vector2 targetDir = ((Vector2)_enemyCollider.transform.position - (Vector2)transform.position).normalized;
        float targetDirAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        float step = rotateSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0, 0, targetDirAngle),
            step
        );

        float moveDirAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        moveDir = new Vector2(Mathf.Cos(moveDirAngle), Mathf.Sin(moveDirAngle));
        _rigid.linearVelocity = moveDir.normalized * speed;
    }

    private void SetDead()
    {
        _isDead = true;
        OnDeadEvent?.Invoke();
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }

    public void ResetItem()
    {
        _isDead = false;
        _enemyCollider = null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }


#endif
}
