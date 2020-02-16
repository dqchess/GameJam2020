using UnityEngine;

public enum ManipulationSate { BreakRock, ChopTree, Pickup, PickupAndHold }

[CreateAssetMenu(menuName = "BCGJ/ObjectManipulation")]
class ObjectManipulation : IAbility
{
    

    public ManipulationSate manipulationSate;

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
