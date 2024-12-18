using UnityEditor;
using UnityEngine;

public class BoomPet : Pet
{
    [Header("Boom Setting")]
    public float ExplosionRadius = 3f;
    public float ExplosionDamageMultiplier = 1f;

    public GameObject boomBulletPrefab;

    private int upgradeLevel = 0;
    private float petDamage;
    private float lastAttackTime = 0f;

    private void SetDamageBasedOnUpgradeLevel()
    {
        switch (upgradeLevel)
        {
            case 0: petDamage = 6f; break;
            case 1: petDamage = 10f; break;
            case 2: petDamage = 12f; break;
            case 3: petDamage = 16f; break;
            case 4: petDamage = 18f; break;
            default: petDamage = 18f; break;
        }
    }

    public void IncreaseLevel()
    {
        if (upgradeLevel >= 5)
        {
            Debug.Log("You can't upgrade this pet any further.");
            return;
        }

        upgradeLevel++;
        SetDamageBasedOnUpgradeLevel();
        Debug.Log($"BoomPet upgraded / petDamage: {petDamage}");
    }

    private void Update()
    {
        if (Time.time - lastAttackTime >= AttackTime)
        {
            RangeDraw();
            lastAttackTime = Time.time;
        }
        //테스트용
        if (Input.GetKeyDown(KeyCode.K))
            IncreaseLevel();
            
    }

    public override void RangeDraw()
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, Range);
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;
        
        foreach (var target in hitTargets)
        {
            if (target.GetComponent<KAYTestEnemyHealth>()) 
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestTarget = target.gameObject; 
                }
            }
        }

        // 가장 가까운 적이 있으면 그 위치로 총알 발사
        if (closestTarget != null)
        {
            Attack(closestTarget);
        }
    }

    protected override void Attack(GameObject target)
    {
        base.Attack(target);
        FireBoomBullet(target.transform.position);
    }

    private void FireBoomBullet(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(boomBulletPrefab, transform.position, Quaternion.identity);

        KAYBoomBullet boomBullet = bullet.GetComponent<KAYBoomBullet>();

        if (boomBullet != null)
        {
            boomBullet.Damage = petDamage; 
            boomBullet.ExplosionRadius = ExplosionRadius;
            boomBullet.ExplosionDamageMultiplier = ExplosionDamageMultiplier;
        }

        Vector3 direction = (targetPosition - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f; // 속도임의
    }
}