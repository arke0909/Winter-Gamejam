using System;
using UnityEngine;

public class BoomPetBullet : PetBullet
{
    [SerializeField] private LayerMask whatIsEnemy;
    
    private float _explosionStartTime;
    private float _boomRange = 3f;
    private const float Duration = 1.5f;

    private Collider2D[] _collider2D;

    private bool _isBooming = false;
    private void Update()
    {
        base.Update();
        if (Time.time - _explosionStartTime > Duration && _isBooming)
        {
            _collider2D = null;
            _isBooming = false;
        }
    }

    protected override void PetHit()
    {
        _collider2D = Physics2D.OverlapCircleAll(transform.position, _boomRange, whatIsEnemy);
        if (_collider2D != null)
        {
            if (_isBooming) return;
            foreach (var obj in _collider2D)
            {
                Debug.Log("붐어택! 무려 여러번이지!");
                damageCaster.CastDamage(_damage, _knockbackPower);
                _isBooming = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _boomRange);
        Gizmos.color = Color.white;
    }
}
