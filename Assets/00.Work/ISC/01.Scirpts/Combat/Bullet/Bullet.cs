using System;
using GGMPool;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolTypeSO poolType;
    
    [SerializeField] protected float speed;
    
    private Rigidbody2D _rigid; 
    private Pool _pool;
    
    public PoolTypeSO PoolType => poolType;
    public GameObject GameObject => this.gameObject;
    
    [field: SerializeField] public float LifeTime { get; set; }
    private float _startTime;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _startTime = Time.time;
        SetMove();
    }

    private void Update()
    {
        CalculateTime();
    }

    private void CalculateTime()
    {
        if (Time.time - _startTime > LifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void SetMove()
    {
        _rigid.linearVelocity = transform.right * speed;
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }

    public virtual void ResetItem()
    {
        _startTime = 0;
    }
}
