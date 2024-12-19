using UnityEngine;

public class SamtanPetBullet : PetBullet
{
    protected override void PetHit()
    {
        Debug.Log("삼탄어택!");
    }
}
