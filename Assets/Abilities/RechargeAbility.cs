using UnityEngine;


[CreateAssetMenu(menuName = "BCGJ/RechargeAbility")]
class RechargeAbility : IAbility
{

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
