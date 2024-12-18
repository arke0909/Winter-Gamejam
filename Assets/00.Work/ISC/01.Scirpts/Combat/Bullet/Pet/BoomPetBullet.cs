using UnityEngine;

public class BoomPetBullet : PetBullet
{
    private float _startTime;
    private float _boomRange = 3f;
    private const float Duration = 1.5f;

    private Collider2D[] _collider2D;
    
    private void Update()
    {
        if (Time.time - _startTime > Duration)
        {
            Destroy(gameObject);
        }
    }

    protected override void PetHit()
    {
        _collider2D = Physics2D.OverlapCircleAll(transform.position, _boomRange);
        if (_collider2D != null)
        {
            foreach (var obj in _collider2D)
            {
                damageCaster.CastDamage(_damage, _knockbackPower);
            }
        }
    }
}
