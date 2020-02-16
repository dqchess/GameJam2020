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
        CreatePartnerID.OnClick.OnTrigger.SetAction((button) => networkInitiator.CreateRoomAsync(NewPartnerIDField.text, OnCreate, OnPartnerConnect));
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
            WaitingViewController cont = UIView.GetViews("General", "Waiting On Player Two")[0].GetComponent<WaitingViewController>();
            cont.GetComponent<UIView>().Show();
            cont.Init(networkInitiator.RoomID);
            UIView.HideView("Connect Window");
        }
    }

    public void OnPartnerConnect(string playerID)
    {
        UIView.HideView("General", "Waiting On Player Two");
    }

}
