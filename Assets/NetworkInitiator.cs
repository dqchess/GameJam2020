using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using Doozy.Engine.UI;
using UnityEngine.UI;


public class NetworkInitiator : MonoBehaviour
{
    // Start is called before the first frame update
    public string PlayerID;

    private DatabaseReference dbReference;

    void Start()
    {
      
    }

    void StartDB()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://bcgj2020p10.firebaseio.com/");
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        if (dbReference != null)
            Debug.Log("CONNECTED");

        if (PlayerPrefs.HasKey("PlayerID"))
        {
            PlayerID = PlayerPrefs.GetString("PlayerID");
        }
        else
        {
            SetPlayerUniqueID();
        }

        WriteNewMessage(DateTime.Now.Ticks.ToString(), DateTime.Now.Ticks, PlayerID, "HELLO" + DateTime.Now.Ticks);
    }

    string SetPlayerUniqueID()
    {
        PlayerID = Guid.NewGuid().ToString();
        PlayerPrefs.SetString("PlayerID", PlayerID);
        return PlayerID;
    }

    public void WriteNewMessage(string messageID, long mesageDateTime, string sentBy, string message)
    {

        Message msg = new Message(messageID, mesageDateTime, sentBy, message);
        string json = JsonUtility.ToJson(msg);

        dbReference.Child("Dummy").Child(messageID).SetRawJsonValueAsync(json);

    }
}

public class Message
{
    public string messageID;
    public string sentBy;
    public long messageDateTime;
    public string message;

    public Message()
    {

    }

    public Message(string messageID, long messageDateTime, string sentBy, string message)
    {
        this.messageID = messageID;
        this.sentBy = sentBy;
        this.messageDateTime = messageDateTime;
        this.message = message;
    }
}
