using UnityEngine;

public class KAYBoomBullet : MonoBehaviour
{
    public float Damage;                  
    public float ExplosionRadius = 3f;    
    public float ExplosionDamageMultiplier = 1f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
        Destroy(gameObject); 
    }

    private void Explode()
    {
      
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D target in hitTargets)
        {
            Health targetHealth = target.GetComponent<Health>();  
            if (targetHealth != null)
            {
               
                float damage = Damage * ExplosionDamageMultiplier;
                //targetHealth.TakeDamage(damage);   
                Debug.Log($"{target.name}에게 {damage}만큼 대미지를 입힘.");
            }
        }

      
    
    }

 
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, ExplosionRadius);
    }
}