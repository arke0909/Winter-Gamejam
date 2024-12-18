using System;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
    [SerializeField] private PetSO petSo;

    protected float Damage => petSo.Damage;
    protected float AttackTime => petSo.AttackTime;
    protected float Range => petSo.AttackRange;

    protected Collider2D Collider2D;

    private void Awake()
    {
        Debug.Assert(petSo != null,$"PetSO is NULL or Empty");
    }

    private void FixedUpdate()
    {
        RangeDraw();
    }

    public virtual void RangeDraw()
    {
        Collider2D = Physics2D.OverlapCircle(transform.position, Range);
        if (Collider2D != null)
        {
            Attack(Collider2D.gameObject);
        }
    }

    protected virtual void Attack(GameObject target)
    {
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
