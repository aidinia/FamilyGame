using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public InputField nameInput;
    public Button createRoom;
    public Button joinRoom;
    private string roomName;


    private void Start()
    {

        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().SetPopUP("Error", "Connection error, please check your internet connection", "Close");

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
    public static void InitiatePlayer()
    {


        var currentPlayers = PhotonNetwork.CurrentRoom.PlayerCount;

       
        var roomPlayers = GameObject.Find("NumOfPlayers");
        var PV = PhotonView.Find(3);
       // GameObject.Find("TextDraw").GetComponent<Text>().text = $"pv {PV}";

        PV.RPC("UpdatePlayers", RpcTarget.All, currentPlayers.ToString());


     //   GameObject.Find("AR Session Origin (1)").GetComponent<Draw>().enabled = true;
    }

    public static void StartGame()
    {
        GameManager.instance.StartGame();

    }

    [PunRPC]
    private void UpdatePlayers(string currentPlayers)
    {

        Debug.Log(currentPlayers);
        var roomPlayers = GameObject.Find("NumOfPlayers").GetComponent<Text>();
        roomPlayers.text = "Current players: " + currentPlayers;



    }
}
