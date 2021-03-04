using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviourPun
{
    Vector2 startPos;

    private void Start()
    {

        var currentPlayers = PhotonNetwork.CurrentRoom.PlayerCount;

        var canvas = GameObject.Find("RoomLobby");
        this.transform.SetParent(canvas.transform);
        var playersCanvas = canvas.transform;
        var placeInX = ((playersCanvas.GetComponent<RectTransform>().rect.width / 4) + this.GetComponent<RectTransform>().rect.width / 2) * currentPlayers;
      

        Debug.Log($"Canvas {playersCanvas.position.x} and place in X {placeInX}");
        Vector3 slot = new Vector3(placeInX, playersCanvas.position.y, playersCanvas.position.z);
        this.transform.position = slot;


    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
               
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (photonView.IsMine)
                {
                    if (Input.GetTouch(0).position.x > startPos.x + 25 )
                    {
                        this.transform.position = this.transform.position + new Vector3(10, 0, 0);
                    }
                    else if (Input.GetTouch(0).position.x < startPos.x + 25)
                    {
                        this.transform.position = this.transform.position + new Vector3(-10, 0, 0);
                    }
                    else if (Input.GetTouch(0).position.y < startPos.y)
                    {
                        this.transform.position = this.transform.position + new Vector3(0, -10, 0);
                    }
                    else if (Input.GetTouch(0).position.y > startPos.y)
                    {
                        this.transform.position = this.transform.position + new Vector3(0, 10, 0);
                    }
                }
            }
        }

        if(Input.GetKeyDown(0) == true)
        {
            if (photonView.IsMine)
            {
                this.transform.position = this.transform.position + new Vector3(0, 10, 0);

            }
        }
    }

}
