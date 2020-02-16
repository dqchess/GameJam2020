using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using TMPro;

public class WaitingViewController : MonoBehaviour
{
    public TextMeshProUGUI playerConnected;
    public TextMeshProUGUI roomIDText;

    public void Init(string roomID)
    {
        roomIDText.SetText("Room ID: " + roomID);
    }
}
