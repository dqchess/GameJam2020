using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMessengerTest : MonoBehaviour
{
    [SerializeField]
    private NetworkMessenger networkMessenger;

    [SerializeField]
    private Button button;

    private int inc = 0;

    private void Start()
    {
        button.onClick.AddListener(() => SendExampleMessage());
    }

    private void SendExampleMessage()
    {
        networkMessenger.SendAbilityMessage("new", "1");
    }
}
