using System;
using UnityEngine;
using GGMPool;

public abstract class Pet : MonoBehaviour
{
    [SerializeField] protected Transform fireForceTrm;
    
    [SerializeField] private PetSO petSo;
    [SerializeField] protected PoolManagerSO poolManagerSO;
    [SerializeField] protected PoolTypeSO poolTypeSO;
    
    [field: SerializeField] public int CurrentLevel { get; protected set; } = 1;
    [field: SerializeField] public int UpgradeArrIdx { get; protected set; } = 0;

    private readonly int _maxLevel = 5;
    [SerializeField] protected float Damage;
    [SerializeField] protected float AttackTime;
    [SerializeField] protected float[] UpgradeArray;
    [SerializeField] protected float Range;
    [SerializeField] protected float KnockbackPower;

    private float cooldown;

    protected Collider2D Collider2D;

    private void Awake()
    {
        Debug.Assert(petSo != null,$"PetSO is NULL or Empty");
        Initialize();
    }

    public void Initialize()
    {
        AttackTime = petSo.AttackTime;
        Damage = petSo.Damage;
        Range = petSo.AttackRange;
        UpgradeArray = petSo.IncreaseValues;
        KnockbackPower = petSo.KnockbackPower;

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
