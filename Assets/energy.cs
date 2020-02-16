using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public float rechargeRate = 0f;
    public float energyLevel = 0f;
    public float decayRate = 0f;

    void OnTriggerEnter(Collider thing)
    {
        Debug.Log("we got in");
        if (thing.tag == "RechargeZone") {
            setRechargeRate(10f);
        }
    }

    void OnTriggerExit(Collider thing)
    {
        if (thing.tag == "RechargeZone") {
            setRechargeRate(0f);
        }
    }

    void Update()
    {
        energyLevel = energyLevel - decayRate + rechargeRate;
        Debug.Log(energyLevel);
    }

    void setRechargeRate(float newRechargeRate) 
    {
        rechargeRate = newRechargeRate;
    }

    void setDecayRate(float newDecayRate) 
    {
        decayRate = newDecayRate;
    }
}