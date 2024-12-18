using UnityEngine;

public class SantanPet : Pet
{
    private Vector3 _dir;
    protected override void Attack(GameObject target)
    {
        _dir = target.transform.position - transform.position;
        float rotate = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        
        transform.localRotation = Quaternion.Euler(0, 0, rotate);
    }
}
