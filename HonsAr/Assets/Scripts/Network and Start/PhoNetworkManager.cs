using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEditor;

public class PhoNetworkManager : MonoBehaviourPunCallbacks
{
    public static PhoNetworkManager instance;
    public Button create;
    public Button find;

    public GameObject RoomLobby;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            gameObject.SetActive(false);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        //        base.OnConnectedToMaster();
        Debug.Log($"Connected to Master");

        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log($"Join Lobby");
        create.interactable = true;
        find.interactable = true;
    }

    public override void OnCreatedRoom()
    {
        //        base.OnCreatedRoom();
        Debug.Log($"Connected to Room {PhotonNetwork.CurrentRoom.Name}");
        RoomLobby.SetActive(true);
        LobbyManager.ChangeMenu(true);

    }
    public override void OnJoinedRoom()
    {

        Debug.Log($"Connected to Room {PhotonNetwork.CurrentRoom.Name}");
        if (!RoomLobby.activeSelf)
        {
            RoomLobby.SetActive(true);

            LobbyManager.ChangeMenu(false);
        }

    }

    public void CreateRoom(string name)
    {
        PhotonNetwork.CreateRoom(name);

        Debug.Log($"Created room name is {name}");

    }

    public void JoindRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

   
}
