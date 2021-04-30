
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviourPun
{
    public GameObject arCam;
    public GameObject brush;
    static List<GameObject> lines = new List<GameObject>();
    LineRenderer currentLine;
    Vector3 lastPosition;
    bool touching = false;

    private void Start()
    {
        GameObject.Find("Clean").GetComponent<Button>().onClick.AddListener(CleanLines);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {

            if (!touching)
            {
              //  GameObject.Find("TextDraw").GetComponent<Text>().text = $"dsfg {touching} \n";

                brush = PhotonNetwork.Instantiate("Brush", arCam.transform.position, arCam.transform.rotation);
               // GameObject.Find("TextDraw").GetComponent<Text>().text += $"brush\n";

                currentLine = brush.GetComponent<LineRenderer>();
                currentLine.SetPosition(0, arCam.transform.position);
                touching = true;
                lastPosition = arCam.transform.position;

            }
            else
            {
                if(lastPosition != arCam.transform.position)
                {
               
                     brush.GetComponent<PhotonView>().RPC("Drawing", RpcTarget.All, arCam.transform.position);

                    lastPosition = arCam.transform.position;
                }
            }


        }
        else
        {
            touching = false;
            lines.Add(brush);
        }
    }

    public void CleanLines()
    {

        foreach (GameObject line in lines)
        {
            PhotonView.Destroy(line);
        }
        lines.Clear();
    }
}
