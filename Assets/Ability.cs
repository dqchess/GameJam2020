using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public enum DiamondState {
        Unowned, Available, Active
    }

    public Dictionary<string, DiamondState> diamondState = new Dictionary<string, DiamondState>();

    void OnTriggerEnter(Collider areaType)
    {
        Debug.Log("we got into " + areaType);
        // if (areaType.tag == "Wet Tile (5)") {
        //     setRechargeRate(10f);
        // }
    }

    void OnTriggerExit(Collider areaType)
    {
        Debug.Log("we LEFT the " + areaType);
        // if (areaType.tag == "Wet Tile (5)") {
        //     setRechargeRate(10f);
        // }
    }

    // void Update()
    // {
    // }

}