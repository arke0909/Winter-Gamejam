using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

[Serializable]
public enum PetType
{
    None,
    BoomPet,
    SlowPet,
    SamtanPet,
}
public class SummonPetSkill : Skill
{
    [SerializeField] private Transform target;
    [SerializeField] private Pet petPrefab;

    private Pet pet = null;

    private static Dictionary<PetType, Pet> _petsDictionary = new Dictionary<PetType, Pet>();

    public void CreatePet(PetType type)
    {
        if (pet != null)
        {
            _petsDictionary[type].Upgrade();
            return;
        }

        GameObject petObj = Instantiate(petPrefab.gameObject, target.position, quaternion.identity);
        petObj.transform.parent = target;
        pet = petObj.GetComponent<Pet>();
        _petsDictionary.Add(type, pet);
    }
}