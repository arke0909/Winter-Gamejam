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
    }

    public override void RangeDraw()
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (var target in hitTargets)
        {
            Attack(target.gameObject);
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

        //아직 그 뭐시기 풀 매니저 어떻게 써야할지 몰라서 이렇게 해둿어요...
        //그리고 폭발 그것도 없길래..

        if (boomBullet != null)
        {
            boomBullet.Damage = petDamage;
            boomBullet.ExplosionRadius = ExplosionRadius;
            boomBullet.ExplosionDamageMultiplier = ExplosionDamageMultiplier;
        }

        // �Ѿ� �߻� ���� ���
        Vector3 direction = (targetPosition - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f; // �ӵ� 5
    }
}
