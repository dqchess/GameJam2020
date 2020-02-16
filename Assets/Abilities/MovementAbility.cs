using UnityEngine;

public enum MovementState { Forward, Backward, Right, Left }

[CreateAssetMenu(menuName = "BCGJ/MovementAbility")]
class MovementAbility : IAbility
{
    public MovementState movementState;

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
