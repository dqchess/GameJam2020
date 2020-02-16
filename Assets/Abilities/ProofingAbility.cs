using UnityEngine;


public enum ProofingType { Wet, Hot, Cold, Air, Float, Ascend, Descend, BothAscDesc }

[CreateAssetMenu(menuName = "BCGJ/ProofingAbility")]
class ProofingAbility : IAbility
{
   

    public ProofingType proofingType;

    public override void Execute(GameObject playerObj)
    {
        playerObj.GetComponent<RoboAbilityController>().ExecuteAbility(this);
    }
}
