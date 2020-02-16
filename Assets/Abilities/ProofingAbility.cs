using UnityEngine;

[CreateAssetMenu(menuName = "BCGJ/ProofingAbility")]
class ProofingAbility : IAbility
{
    public enum ProofingType { Wet, Hot, Air, Float, Ascend, Descend }

    public ProofingType proofingType;

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
