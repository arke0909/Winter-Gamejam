using UnityEngine;

public interface IHittable
{
    public void GetHit(GameObject gameObject, int damage);
}
