using System;
using GGMPool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

    public void SetDir(Vector3 position , Vector3 dir)
    {
        transform.position = position;
        transform.right = dir;
        _rigid.linearVelocity = transform.right * speed;
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }

    public void ResetItem()
    {
        _startTime = 0;
    }
}
