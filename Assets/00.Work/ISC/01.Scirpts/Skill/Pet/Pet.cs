using System;
using UnityEngine;
using GGMPool;

public abstract class Pet : MonoBehaviour
{
    [SerializeField] private PetSO petSo;
    [SerializeField] protected PoolManagerSO poolManagerSO;
    [SerializeField] protected PoolTypeSO poolTypeSO;
    
    [field: SerializeField] public int CurrentLevel { get; protected set; } = 1;
    [field: SerializeField] public int UpgradeArrIdx { get; protected set; } = 0;

    private readonly int _maxLevel = 5;
    protected float Damage => petSo.Damage;
    protected float AttackTime;
    protected float[] UpgradeArray;
    protected float Range => petSo.AttackRange;
    protected float KnockbackPower => petSo.KnockbackPower;

    private float cooldown;

    protected Collider2D Collider2D;

    private void Awake()
    {
        Debug.Assert(petSo != null,$"PetSO is NULL or Empty");
        Initalize();
    }

    private void Initalize()
    {
        AttackTime = petSo.AttackTime;
        UpgradeArray = petSo.IncreaseValues;

        AfterInit();
    }

    protected virtual void AfterInit()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Upgrade();
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0)
            {
                cooldown = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        RangeDraw();
    }

    public virtual void Upgrade()
    {
        if (CurrentLevel >= _maxLevel || UpgradeArrIdx + 1 >= UpgradeArray.Length) return;
        CurrentLevel++;
        UpgradeArrIdx++;
    }

    public virtual void RangeDraw()
    {
        Collider2D = Physics2D.OverlapCircle(transform.position, Range);
        if (Collider2D != null)
        {
            if (CheckAttemptAttack())
                Attack(Collider2D.gameObject);
        }
    }

    private bool CheckAttemptAttack()
    {
        if (cooldown <= 0)
        {
            cooldown = AttackTime;
            return true;
        }

        return false;
    }

    protected virtual void Attack(GameObject target)
    {
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
