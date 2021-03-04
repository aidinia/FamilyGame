using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public Text roomName;
    public Button startButton;
    [SerializeField] public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // thisPlayer.transform.parent = playersCanvas;

    }

    // Update is called once per frame
    void Update()
    {
        //roomName.text = PhotonNetwork.CurrentRoom.Name + " - Current players: " + PhotonNetwork.CurrentRoom.PlayerCount;

    }
}
