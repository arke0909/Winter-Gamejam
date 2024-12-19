using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class SummonSamtanSkill : Skill
{
    [SerializeField] private Transform target;
    [SerializeField] private Pet petPrefab;

    private Pet pet = null;

    protected override void Upgrade()
    {
        if (pet != null)
        {
            pet.Upgrade();
            return;
        }

        GameObject petObj = Instantiate(petPrefab.gameObject, target.position, quaternion.identity);
        petObj.transform.parent = target;
        pet = petObj.GetComponent<Pet>();
    }
}