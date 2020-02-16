using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unowned: ability not owned, Available: owned by not activated, Activate: ability is on
public enum AbilityState {
    Unowned, Available, Active
}

[CreateAssetMenu(fileName = "Ability", menuName = "~/dev/GameJam2020/Assets/Ability.cs/Ability", order = 0)]
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