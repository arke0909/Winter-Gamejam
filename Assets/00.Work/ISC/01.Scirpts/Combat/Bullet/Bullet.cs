using GGMPool;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolManagerSO poolManagerSo;
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] protected DamageCaster damageCaster;
    
    [SerializeField] protected float speed;
    
    private Rigidbody2D _rigid;
    private Pool _pool;

    private bool _isDead = false;

    protected float _damage, _knockbackPower;

    protected GameObject Target;

    [SerializeField]
    protected int PenetrationCnt = 0;
    
    public PoolTypeSO PoolType => poolType;
    public GameObject GameObject => this.gameObject;
    
    [field: SerializeField] public float LifeTime { get; set; }
    private float _startTime;
    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _startTime = Time.time;
    }

    protected  void Update()
    {
        CalculateTime();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDead) return;
        Target = other.gameObject;
        Hit();

        damageCaster.CastDamage(_damage, _knockbackPower);
        if (PenetrationCnt <= 0)
        {
            poolManagerSo.Push(this);
            return;
        }
        PenetrationCnt--;
    }

    protected abstract void Hit();

    private void CalculateTime()
    {
        if (Time.time - _startTime > LifeTime)
        {
            _isDead = true;
            poolManagerSo.Push(this);
        }
    }

    public void Initialize(Vector3 position , Vector3 dir, float damage, float knockbackPower)
    {
        transform.position = position;
        transform.right = dir.normalized;
        SetMove(transform.right);
        _damage = damage;
        _knockbackPower = knockbackPower;
    }

    private void SetMove(Vector2 dir)
    {
        _rigid.linearVelocity = dir * speed;
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }

    public virtual void ResetItem()
    {
        _startTime = Time.time;
        _isDead = false;
    }
}
