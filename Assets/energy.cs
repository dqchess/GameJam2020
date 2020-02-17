using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public float rechargeRate = 0f;
    public float energyLevel = 1f;
    public float maxEnergy = 1000f;
    public float decayRate = 0f;
    public Bar bar;
    bool full;

    void OnTriggerEnter(Collider thing)
    {
        Debug.Log("we got in");
        if (thing.tag == "Sun") {
            setRechargeRate(10f);
        }
    }

    void OnTriggerExit(Collider thing)
    {
        if (thing.tag == "Sun") {
            setRechargeRate(0f);
        }
        full = false;
    }

    void Start()
    {
      Debug.Log("energy set");
      bar.SetMaxEnergy(maxEnergy);
    }

    void Update()
    {
        if (!full)
        {
            energyLevel = energyLevel - decayRate + rechargeRate;
            if (energyLevel > maxEnergy)
            {
                energyLevel = maxEnergy;
                full = true;
            }
            if (energyLevel < 0)
            {
                energyLevel = 1;
            }
        }
        bar.SetEnergy(energyLevel);
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
