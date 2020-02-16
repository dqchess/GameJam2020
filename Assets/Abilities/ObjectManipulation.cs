using UnityEngine;

[CreateAssetMenu(menuName = "BCGJ/ObjectManipulation")]
class ObjectManipulation : IAbility
{
    public enum ManipulationSate { BreakRock, ChopTree, Pickup, PickupAndHold }

    public ManipulationSate manipulationSate;

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
