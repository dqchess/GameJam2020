using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAbilityManager : MonoBehaviour
{
    public List<IAbility> abilities = new List<IAbility>();

    public IAbility GetAbilityByID(string id)
    {
        IAbility abs = null;
        foreach(var ability in abilities)
        {
            if(ability.id == id)
            {
                abs = ability;
                break;
            }
        }

        return abs;
    }
}
