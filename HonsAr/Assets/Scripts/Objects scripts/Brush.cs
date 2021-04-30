using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brush : MonoBehaviourPun
{
    
    [PunRPC]
    private void Drawing(Vector3 position)
    {

        this.GetComponent<LineRenderer>().positionCount++;
        int index = this.GetComponent<LineRenderer>().positionCount - 1;
        this.GetComponent<LineRenderer>().SetPosition(index,position);

    }
}
