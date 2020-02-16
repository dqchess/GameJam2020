using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using Doozy.Engine.UI;
using UnityEngine.UI;
using UnityEngine.Events;

public class NetworkInitiator : MonoBehaviour
{
    // Start is called before the first frame update
    public string PlayerID;
    public string RoomID;
    private DatabaseReference dbReference;


    void Start()
    {
        StartDB();
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

    public async System.Threading.Tasks.Task ConnectToRoomAsync(string roomID, UnityAction<bool, string> callback)
    {
        var initialGetResult = await dbReference.Child("Rooms").Child(roomID).GetValueAsync();

        if(initialGetResult.Exists)
        {
            DataSnapshot snapshot = initialGetResult;

            if (snapshot.Value == null)
            {
                callback(false, "Room with this id doesn't exist.");
            }
            else
            {
                foreach (var child in snapshot.Children)
                {
                    if (child.Key == "PlayerTwoID")
                    {
                        if (child.Value.ToString() == "")
                        {
                            await dbReference.Child("Rooms").Child(roomID).Child("PlayerTwoID").SetValueAsync(PlayerID);
                            RoomID = roomID;
                            callback(true, "Connected!");
                        }
                        else
                        {
                            callback(false, "Room is full.");
                        }
                        break;
                    }
                }
            }
        }
    }

    public async System.Threading.Tasks.Task CreateRoomAsync(string roomID, UnityAction<bool, string> callback)
    {
        string json = JsonUtility.ToJson(new Room(roomID, PlayerID, ""));

        var initialGetResult = await dbReference.Child("Rooms").Child(roomID).GetValueAsync();
        if(initialGetResult.Value == null)
        {
            await dbReference.Child("Rooms").Child(roomID).SetRawJsonValueAsync(json);
            callback(true, "Success! Room is created.");
        }
        else
        {
            callback(false, "Room with that ID is already created");
        }
    }
}

public class Message
{
    public string messageID;
    public string sentBy;
    public long messageDateTime;
    public string message;

    public Message(string messageID, long messageDateTime, string sentBy, string message)
    {
        this.messageID = messageID;
        this.sentBy = sentBy;
        this.messageDateTime = messageDateTime;
        this.message = message;
    }
}

public class Room
{
    public string RoomID;
    public string PlayerOneID;
    public string PlayerTwoID;

    public Room (string RoomID, string PlayerOneID, string PlayerTwoID)
    {
        this.RoomID = RoomID;
        this.PlayerOneID = PlayerOneID;
        this.PlayerTwoID = PlayerTwoID;
    }
}
