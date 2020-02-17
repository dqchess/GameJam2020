using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    bool carrying;
    private Transform theDest;
    public NetworkMessenger netwrk;
    public Animator animator;
    public AudioSource actionAudio;
    public AudioClip pickupSound;
    public AudioClip chopSound;
    public AudioClip breakSound;
    public string newAbility;

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
            actionAudio.PlayOneShot(pickupSound);
            Attack();
            newAbility = other.gameObject.name;
            netwrk.SendAbilityMessage("new",newAbility);
            Destroy(other.gameObject);

            // Message Packer
        }

        if(ableToGrabandHold && other.tag == "item")
        {
            actionAudio.PlayOneShot(pickupSound);
            Attack();
            Destroy(other.gameObject);
            // Update GUI
        }

        if (ableToBreakRocks && other.tag == "rock")
        {
            actionAudio.PlayOneShot(breakSound);
            Attack();
            Destroy(other.gameObject);
        }

        if(ableToChopTree && other.tag == "tree")
        {
            actionAudio.PlayOneShot(chopSound);
            Attack();
            Destroy(other.gameObject);
        }

        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

}
