using UnityEngine;

public class SlowPet : Pet
{


    public GameObject boomBulletPrefab;

    private int upgradeLevel = 0;
    private float slowPersent;
    private float lastAttackTime = 0f;

    private void SetDamageBasedOnUpgradeLevel()
    {
        switch (upgradeLevel)
        {
            case 0: slowPersent = 0.15f; break;
            case 1: slowPersent = 0.20f; break;
            case 2: slowPersent = 0.25f; break;
            case 3: slowPersent = 0.30f; break;
            case 4: slowPersent = 0.40f; break;
            default: slowPersent = 0.40f; break;
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
        Debug.Log($"slowPet upgraded / slow: {slowPersent}");
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

        // 가장 가까운 적
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

        KAYSlowBullet slowBullet = bullet.GetComponent<KAYSlowBullet>();

        if (slowBullet != null)
        {


            Vector3 direction = (targetPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f; // 속도임의
        }
    }
}
