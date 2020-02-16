using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartnerConnectController : MonoBehaviour
{
    [SerializeField]
    private Button ConnectButton;

    [SerializeField]
    private Button CreatePartnerID;

    [SerializeField]
    private InputField PartnerIDField;

    [SerializeField]
    private InputField NewPartnerIDField;

    [SerializeField]
    private NetworkInitiator networkInitiator;

    [SerializeField]
    private Text OnCreateText;

    [SerializeField]
    private Text OnConnectText;

    public GameObject thisView;
    public GameObject ConnectView;
    // Start is called before the first frame update
    void Start()
    {
        ConnectButton.onClick.AddListener(() => networkInitiator.ConnectToRoomAsync(PartnerIDField.text, OnConnect));
        CreatePartnerID.onClick.AddListener(derp);
    }

    void derp()
    {
        networkInitiator.CreateRoomAsync(NewPartnerIDField.text, OnCreate, OnPartnerConnect);

    }

    public void OnConnect(bool status, string message)
    {
        if (!status)
        {
            OnConnectText.text = (message);
        }
        else
        {
            thisView.SetActive(false);
        }
    }

    public void OnCreate(bool status, string message)
    {
        if (!status)
        {
            OnCreateText.text = (message);
        }
        else
        {
            //WaitingViewController cont = UIView.GetViews("General", "Waiting On Player Two")[0].GetComponent<WaitingViewController>();
            //cont.GetComponent<UIView>().Show();
            //cont.Init(networkInitiator.RoomID);
            //UIView.HideView("Connect Window");
            thisView.SetActive(false);
            ConnectView.SetActive(true);
            //ConnectView.GetComponent<WaitingViewController>().Init(networkInitiator.RoomID);
            
        }
    }

    public void OnPartnerConnect(string playerID)
    {
        ConnectView.SetActive(false);
        //UIView.HideView("General", "Waiting On Player Two");
    }

}
