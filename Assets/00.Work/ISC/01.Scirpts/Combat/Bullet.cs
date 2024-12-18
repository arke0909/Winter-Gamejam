using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    
    private Rigidbody2D _rigid;
    
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
}
