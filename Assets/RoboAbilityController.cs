using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAbilityController : MonoBehaviour
{
    public Proofing proofingController;
    public Movement movementController;
    public Radar radarController;
    public Pick objManipulationController;

    public RoboAbilityManager manager;

    // Start is called before the first frame update
    public void ExecuteAbility(IAbility ability)
    {
        switch (ability.abilityType)
        {
            case AbilityType.Movement:
                movementController.ActivateMovementAbility(((MovementAbility)ability).movementState, true);
                break;
            case AbilityType.ObjectManipulation:
                objManipulationController.UpdatePickAbility(((ObjectManipulation)ability).manipulationSate, true);
                break;
            case AbilityType.Proofing:
                proofingController.ToggleProofing(((ProofingAbility)ability).proofingType, true);
                break;
            case AbilityType.Radar:
                radarController.isRadarOn = true;
                break;
            case AbilityType.Recharge:
                //TODO ADD ENERGY
                break;
        }
    }

    public void DeactivateAbility(IAbility ability)
    {
        switch (ability.abilityType)
        {
            case AbilityType.Movement:
                movementController.ActivateMovementAbility(((MovementAbility)ability).movementState, false);
                break;
            case AbilityType.ObjectManipulation:
                objManipulationController.UpdatePickAbility(((ObjectManipulation)ability).manipulationSate, false);
                break;
            case AbilityType.Proofing:
                proofingController.ToggleProofing(((ProofingAbility)ability).proofingType, false);
                break;
            case AbilityType.Radar:
                radarController.isRadarOn = false;
                break;
        }
    }
}
