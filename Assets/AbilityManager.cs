using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AbilityManager : MonoBehaviour
{
    public PackingManager pckingManager;
    public RoboAbilityManager manager;
    public void UpdateAbility(AbilityMessage msg)
    {
        string stat = msg.abilityState;
        int abilityID = Convert.ToInt32(msg.abilityID);

        if(SceneManager.GetActiveScene().name == "PackingScene")
        {
            if (stat == "new")
                pckingManager.SpawnAbility((AbilityID)abilityID);
        }
        else if (SceneManager.GetActiveScene().name == "World1")
        {

            if (stat == "active")
            {
                Debug.Log("ACTIVATE: " + msg.ToString());
                manager.GetAndActivateAbilityByID((AbilityID)(Convert.ToInt32(msg.abilityID)));
            }
            if (stat == "inactive")
            {
                Debug.Log("DEACTIVATE: " + msg.ToString());
                manager.GetAndDeActivateAbilityByID((AbilityID)(Convert.ToInt32(msg.abilityID)));
            }


        }
      
    }
}
