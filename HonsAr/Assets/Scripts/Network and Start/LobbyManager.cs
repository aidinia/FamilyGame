using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEditor;

public class LobbyManager : MonoBehaviour
{
    public InputField nameInput;
    public Button createRoom;
    public Button joinRoom;



    public int index = 0;
    Object[] guids2;
    private string roomName;


    private void Awake()
    {
        // Load icons
        guids2 = Resources.LoadAll("ARISAN/100 Alchemy item icons-free", typeof(Sprite));
    }
    private void Start()
    {

        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().SetPopUP("Error", "Connection error, please check your internet connection","Close");

        }

        createRoom.onClick.AddListener(OnClickCreateRoom);

        joinRoom.onClick.AddListener(OnClickJoinRoom);

    }

    public void OnClickCreateRoom()
    {
        roomName = nameInput.text;// == null ? PhotonNetwork.CountOfRooms.ToString() : nameInput.text;
        PhoNetworkManager.instance.CreateRoom(roomName);

    }
    public void OnClickJoinRoom()
    {

        Debug.Log($"JoinRoom");

        roomName = nameInput.text;
        PhoNetworkManager.instance.JoindRoom(roomName);
    }


    public void ChangeIcon()
    {
        index++;
        Debug.Log($"Index is {index} and icons are {guids2.Length}");
        if (index == guids2.Length)
        {
            index = 0;
        }
        var icon = guids2[index];
        GameObject thisPlayer = GameObject.Find("LocalPlayer");
        thisPlayer.GetComponent<Image>().sprite = (Sprite)icon;
    }

    public static void ChangeMenu(bool starter)
    {

        var roomName = GameObject.Find("RoomName").GetComponent<Text>();

        roomName.text = PhotonNetwork.CurrentRoom.Name;

        var roomPlayers = GameObject.Find("NumOfPlayers").GetComponent<Text>();
      //  roomPlayers.GetComponent<PhotonView>().RPC("UpdatePlayers", RpcTarget.All, PhotonNetwork.CurrentRoom.PlayerCount.ToString());

        var startGameButton = GameObject.Find("StartGame").GetComponent<Button>();


        if (starter)
        {
            startGameButton.onClick.AddListener(StartGame);
        }
        else
        {
            GameObject.Find(startGameButton.name).SetActive(false);
        }

        GameObject.Find("EnterMenu").SetActive(false);


        InitiatePlayer();
    }

    public void CreatePlayer()
    {

        var playerHolder = GameObject.Find("PlayerHolder");
        var playerData = GameObject.Find("LocalPlayer");
        playerHolder.GetComponent<Image>().sprite = playerData.GetComponent<Image>().sprite;
        playerHolder.GetComponentInChildren<Text>().text = GameObject.Find("LocalPlayerName").GetComponent<InputField>().text;

    }
    public static void InitiatePlayer(){

    
        var currentPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
      //  var RoomLobby = GameObject.Find("RoomLobby").GetComponent<Canvas>();
        var playerHolder = GameObject.Find("PlayerHolder");

        var thisPlayer = PhotonNetwork.Instantiate("Player00" + currentPlayers, playerHolder.transform.position, playerHolder.transform.rotation);
        thisPlayer.transform.parent = playerHolder.transform.parent;
        GameObject.Destroy(playerHolder);
        var roomPlayers = GameObject.Find("NumOfPlayers").GetComponent<Text>();
        roomPlayers.text = $"Current players: {currentPlayers}";
      //  roomPlayers.RPC("UpdatePlayers", RpcTarget.All, currentPlayers.ToString());
    }

    public static void StartGame()
    {
        GameManager.instance.StartGame();//.LoadLevel("Planets");
        
    }

    [PunRPC]
    public void UpdatePlayers(string currentPlayers)
    {
        var roomPlayers = GameObject.Find("NumOfPlayers").GetComponent<Text>();
        roomPlayers.text = "Current players: " + currentPlayers;

    }
}
