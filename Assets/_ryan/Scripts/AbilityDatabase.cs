using UnityEngine;
using System.Collections;

[System.Serializable]
public enum AbilityID
{
    Mfor,
    Mlef,
    Mrig,
    Mbac,
    Ewat,
    Ehot,
    Ecol,
    Eflo,
    Ehov,
    Casc,
    Cdec,
    Call,
    Itre,
    Iroc,
    Pabi,
    Pite,
    Rada,
    Fusi
}

[System.Serializable]
public struct AbilityReference {
    public AbilityID id;
    public GameObject block;
}

[CreateAssetMenu(fileName = "AbilityDatabase", menuName = "BCGJ", order = 1)]
public class AbilityDatabase : ScriptableObject
{
    [SerializeField]
    public AbilityReference[] abilities;
}
