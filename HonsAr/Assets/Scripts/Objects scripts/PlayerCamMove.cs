using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamMove : MonoBehaviourPun
{

    private TextMesh text;

    private void Start()
    {
         Application.targetFrameRate = 300;
    }
    private void Update()
    {
        GameObject.Find("MyPosition").GetComponent<Text>().text = $"My position: {this.transform.position}\n";

    }
}
