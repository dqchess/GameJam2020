using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class NetworkMessenger : MonoBehaviour
{
    public string ListeningCode;
    public string PushingCode;
    public string PlayerID;
    public string TheOtherPlayerID;
    private DatabaseReference dbReference;

    public UnityAction<AbilityMessage> OnMessageUpdate;
    public AbilityManager abilityManager;

    public void Init(DatabaseReference reference, string roomID, string playerID, string theOtherPlayerID)
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://bcgj2020p10.firebaseio.com/");
        this.dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        this.PlayerID = playerID;
        this.TheOtherPlayerID = theOtherPlayerID;
        this.ListeningCode = roomID + theOtherPlayerID;
        this.PushingCode = roomID + playerID;

        this.dbReference.Child("Messages").Child(PushingCode).SetRawJsonValueAsync(JsonUtility.ToJson(new AbilityMessage()));
        this.dbReference.Child("Messages").Child(ListeningCode).SetRawJsonValueAsync(JsonUtility.ToJson(new AbilityMessage()));
        SetupDBListener();
    }

    public void SendAbilityMessage(string abilityState, string abilityID)
    {
        AbilityMessage msg = new AbilityMessage(PushingCode, DateTime.Now.Ticks.ToString(), abilityState, abilityID, this.PlayerID);
        Debug.Log(msg.ToString());
        string jsonifiedMessage = JsonUtility.ToJson(msg);
        this.dbReference.Child("Messages").Child(PushingCode).SetRawJsonValueAsync(jsonifiedMessage);
    }

    public void SetupDBListener()
    {
        this.dbReference.Child("Messages").Child(ListeningCode).ValueChanged += HandleMessageValueChange;
        //this.dbReference.Child("Messages").Child(PushingCode).ValueChanged += HandleMessageValueChange;
    }

    void HandleMessageValueChange(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        else
        {
            DataSnapshot snapshot = args.Snapshot;
            AbilityMessage msg = new AbilityMessage();

            foreach (var child in snapshot.Children)
            {
                switch (child.Key)
                {
                    case "messageID":
                        msg.messageID = child.Value.ToString();
                        break;
                    case "sentBy":
                        msg.sentBy = child.Value.ToString();
                        break;
                    case "messageDateTime":
                        msg.messageDateTime = child.Value.ToString();
                        break;
                    case "abilityState":
                        msg.abilityState = child.Value.ToString();
                        break;
                    case "abilityID":
                        msg.abilityID = child.Value.ToString();
                        break;
                }
            }

            abilityManager.UpdateAbility(msg);
            Debug.Log(msg.ToString());
        }
    }
}

public class AbilityMessage
{
    public string messageID;
    public string sentBy;
    public string messageDateTime;
    public string abilityState;
    public string abilityID;

    public AbilityMessage()
    {

    }

    public AbilityMessage(string messageID, string messageDateTime, string abilityState, string abilityID, string sentBy)
    {
        this.messageID = messageID;
        this.sentBy = sentBy;
        this.messageDateTime = messageDateTime;
        this.abilityState = abilityState;
        this.abilityID = abilityID;
    }

    public override string ToString()
    {
        return abilityID + abilityState;
    }
}