using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using UnityEngine.UI;
using TMPro;

public class PartnerConnectController : MonoBehaviour
{
    [SerializeField]
    private UIButton Connect;

    [SerializeField]
    private UIButton CreatePartnerID;

    [SerializeField]
    private TMP_InputField PartnerIDField;

    [SerializeField]
    private NetworkInitiator networkInitiator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
