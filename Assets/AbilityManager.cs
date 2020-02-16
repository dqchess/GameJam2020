using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public PackingManager pckingManager;

    public void UpdateAbility(AbilityMessage msg)
    {
        string stat = msg.abilityState;
        int abilityID = Convert.ToInt32(msg.abilityID);
        if (stat == "new")
            pckingManager.SpawnAbility((AbilityID)abilityID);
    }
}
