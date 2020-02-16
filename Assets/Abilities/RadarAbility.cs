using UnityEngine;

[CreateAssetMenu(menuName = "BCGJ/RadarAbility")]
class RadarAbility : IAbility
{

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
