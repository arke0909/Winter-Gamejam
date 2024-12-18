using UnityEngine;

public class KAYBoomBullet : MonoBehaviour
{
    public float Damage;
    public float ExplosionRadius;
    public float ExplosionDamageMultiplier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
       
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D target in hitTargets)
        {
           
            if (target.CompareTag("Enemy"))
            {
               
               
            }
        }

       
    }


    
}
