using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType { Proofing, Movement, Radar, ObjectManipulation}
public abstract class IAbility : ScriptableObject
{
    public string id;
    public int energyCost;
    public bool droppable;
    public AbilityType abilityType;
    
    public virtual void Execute(GameObject playerObj)
    {

    }
}
