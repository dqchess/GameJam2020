using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unowned: ability not owned, Available: owned by not activated, Activate: ability is on
public enum AbilityState {
    Unowned, Available, Active
}

[CreateAssetMenu(menuName = "Ability")]
public class Ability : ScriptableObject
{
    public AbilityState state = Unowned;
    public new string name;
    public string description;
    public int size;
    public float volume;
    public int energyCost;
    public bool droppable;
    public string id;
}