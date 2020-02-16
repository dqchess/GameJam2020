using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using UnityEngine.UI;
using TMPro;

public class PartnerConnectController : MonoBehaviour
{
    [SerializeField]
    private UIButton ConnectButton;

    [SerializeField]
    private UIButton CreatePartnerID;

    [SerializeField]
    private TMP_InputField PartnerIDField;

    [SerializeField]
    private TMP_InputField NewPartnerIDField;

    [SerializeField]
    private NetworkInitiator networkInitiator;

    [SerializeField]
    private TMPro.TMP_Text OnCreateText;

    [SerializeField]
    private TMPro.TMP_Text OnConnectText;

    public UIView view;
    // Start is called before the first frame update
    void Start()
    {
        ConnectButton.OnClick.OnTrigger.SetAction((button) => networkInitiator.ConnectToRoomAsync(PartnerIDField.text, OnConnect));
        CreatePartnerID.OnClick.OnTrigger.SetAction((button) => networkInitiator.CreateRoomAsync(NewPartnerIDField.text, OnCreate));
    }

    public void OnConnect(bool status, string message)
    {
        if (!status)
        {
            OnConnectText.SetText(message);
        }
        else
        {
            view.Hide(false);
        }
    }

    public void OnCreate(bool status, string message)
    {
        if (!status)
        {
            OnCreateText.SetText(message);
        }
        else
        {
            UIView.HideView("Connect Window"); 
        }
    }


}
