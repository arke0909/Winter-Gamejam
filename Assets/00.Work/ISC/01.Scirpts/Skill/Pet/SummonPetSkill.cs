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
    [SerializeField] private List<Pet> pets;

    private Dictionary<PetType, Pet> _currentPets = new Dictionary<PetType, Pet>();

    public void CreatePet(PetType type)
    {
        if (_currentPets.ContainsKey(type))
        {
            _currentPets[type].Upgrade();
            return;
        }

        foreach (Pet item in pets)
        {
            Transform trm = item.transform;
            if (type.ToString() == item.name)
            {
                GameObject petGo = Instantiate(item.gameObject, trm.position, quaternion.identity);
                petGo.transform.position = target.transform.position;
                petGo.SetActive(true);
                Pet pet = petGo.GetComponent($"{type}") as Pet;
                _currentPets.Add(type, pet);
            }
        }
    }
}