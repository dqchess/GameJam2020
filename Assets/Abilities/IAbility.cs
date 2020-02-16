using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType { Proofing, Movement, Radar, ObjectManipulation, Recharge}
public abstract class IAbility : ScriptableObject
{
    public string id;
    public int energyCost;
    public bool droppable;
    public AbilityType abilityType;
    
    public virtual void Execute(GameObject playerObj)
    {

    }

    public virtual void Deactivate(GameObject obj)
    {
        obj.GetComponent<RoboAbilityController>().DeactivateAbility(this);
    }
}
