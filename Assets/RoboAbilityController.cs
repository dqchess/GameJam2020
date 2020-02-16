using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAbilityController : MonoBehaviour
{
    public Proofing proofingController;
    public Movement movementController;
    public Radar radarController;
    public Pick objManipulationController;

    // Start is called before the first frame update
    public void ExecuteAbility(IAbility ability)
    {
        //switch (type)
        //{
        //    case AbilityType.Movement:
        //        movementController.
        //}
    }

    public void DeactivateAbility(IAbility ability)
    {

    }
}
