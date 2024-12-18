using UnityEditor;
using UnityEngine;

public class BoomPet : Pet
{
    [Header("Boom Setting")]
    public float ExplosionRadius = 3f;
    public float ExplosionDamageMultiplier = 1f;

    protected override void Attack(GameObject target)
    {
        base.Attack(target);

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        float explosionDamage = Damage * ExplosionDamageMultiplier;

        foreach (var hitTarget in hitTargets)
        {
            if (hitTarget.gameObject != target) continue;

            // �ｺ�� ���\
          

            Debug.Log($"�¾Ҵ��� {hitTarget.name} ������ : {explosionDamage}");
        }
    }

    private void Update()
    {
        if (Time.time % AttackTime < 0.1f)
        {
            RangeDraw();
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

     
}
