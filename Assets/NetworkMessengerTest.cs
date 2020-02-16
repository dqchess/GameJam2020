using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class NetworkMessengerTest : MonoBehaviour
{
    [SerializeField]
    private NetworkMessenger networkMessenger;

    [SerializeField]
    private UIButton button;

    private int inc = 0;

    private void Start()
    {
        button.OnClick.OnTrigger.SetAction((button) => SendExampleMessage());
    }

    private void SendExampleMessage()
    {
        networkMessenger.SendAbilityMessage("test", "this shit ability sucks" + inc++);
    }
}
