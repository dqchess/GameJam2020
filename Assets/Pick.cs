using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool carrying;
    private Transform theDest;

    public NetworkMessenger netwrk;
    private string newAbility;

    bool ableToAcquireAbility = true;
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
            newAbility = other.gameObject.name;
            netwrk.SendAbilityMessage("new", newAbility);
            Attack();
            Destroy(other.gameObject);
            // Message Packer
        }

        if(ableToGrabandHold && other.tag == "item")
        {
            Attack();
            Destroy(other.gameObject);
            // Update GUI
        }

        if (ableToBreakRocks && other.tag == "rock")
        {
            Attack();
            Destroy(other.gameObject);
        }

        if(ableToChopTree && other.tag == "tree")
        {
            Attack();
            Destroy(other.gameObject);
        }

        

        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

}
