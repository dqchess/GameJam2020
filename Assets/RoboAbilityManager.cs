using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAbilityManager : MonoBehaviour
{
    public List<IAbility> abilities = new List<IAbility>();
    [SerializeField] private AbilityDatabase abilityDatabase = null;
    public RoboAbilityController controller;

    public IAbility GetAndActivateAbilityByID(AbilityID id)
    {
        IAbility ability = Array.Find(abilityDatabase.abilities, x => (x.id == id)).iAbility;

        controller.ExecuteAbility(ability);

        return ability;
    }

    public IAbility GetAndDeActivateAbilityByID(AbilityID id)
    {
        IAbility ability = Array.Find(abilityDatabase.abilities, x => (x.id == id)).iAbility;

        controller.DeactivateAbility(ability);

        return ability;
    }
}
