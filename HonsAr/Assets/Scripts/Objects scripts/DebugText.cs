using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviourPun
{

    [PunRPC]
    private void AddText(string text)
    {

        this.GetComponent<Text>().text += text + "\n";

    }
}
