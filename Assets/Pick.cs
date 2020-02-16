using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    bool carrying;
    public Transform theDest;

    bool ableToAcquireAbility;
    bool ableToGrabandHold;
    bool ableToChopTree;
    bool ableToBreakRocks;

    public void UpdatePickAbility(ManipulationSate state, bool value)
    {
        switch (state)
        {
            case ManipulationSate.BreakRock:
                ableToBreakRocks = value;
                break;
            case ManipulationSate.ChopTree:
                ableToChopTree = value;
                break;
            case ManipulationSate.Pickup:
                ableToAcquireAbility = value;
                break;
            case ManipulationSate.PickupAndHold:
                ableToGrabandHold = value;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(ableToAcquireAbility && other.tag == "ability")
        {
            Destroy(other.gameObject);
            // Message Packer
        }

        if(ableToGrabandHold && other.tag == "item")
        {
            Destroy(other.gameObject);
            // Update GUI
        }

        if (ableToBreakRocks && other.tag == "rock")
        {
            Destroy(other.gameObject);
        }

        if(ableToChopTree && other.tag == "tree")
        {
            Destroy(other.gameObject);
        }

        
    }

}
