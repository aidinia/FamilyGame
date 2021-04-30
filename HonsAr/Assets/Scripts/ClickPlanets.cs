using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPlanets : MonoBehaviour
{

    public Camera cam;
    public GameObject PopUpFacts;
    public Button NextLevelButton;

    private List<string> facts = new List<string>();
    private int factIndex = 0;
    List<string> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    private void Start()
    {
        GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().SetPopUP("Planets", $"Today {DateTime.Now.Day} of {months[DateTime.Now.Month - 1]}, the planets are in a specific coordinates respect to planet Earth.", "Close");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            var touch = Input.GetTouch(0).position;

            var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (Level.currentItems.IndexOf(selection.name)<0)
                {

                    if (!PopUpFacts.activeSelf && Planet.facts.ContainsKey(selection.name))
                    {
                        OpenPopUpFacts(selection.name);

                    }
                }
                else
                {
                    var viewToDestroy = GameObject.Find(selection.name);
                    var original = (GameObject)Resources.Load(selection.name.Replace("(Clone)", ""));
                    viewToDestroy.transform.localScale = original.transform.localScale/3;
                    viewToDestroy.transform.position = original.transform.position;
                    GameObject.Find("DebugCanvas").GetComponent<PhotonView>().RPC("AddText", RpcTarget.All, $"Planet found : {viewToDestroy.name} Moved to { original.transform.position} ");
                    viewToDestroy.GetComponent<PhotonView>().RPC("RemovePlanet", RpcTarget.All, selection.name);

                    if (Level.currentItems.Count == 0)
                    {
                        GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().OpenPopUp();
                        NextLevelButton.gameObject.SetActive(true);
                    }
                }
            }

        }
    }


    public void NextLevel()
    {
        Level.pass = true;
    }

    public void OpenPopUpFacts(string planetName)
    {

        facts = Planet.facts[planetName];


        PopUpFacts.SetActive(true);
        GameObject.Find("popUpContentFacts").GetComponent<Text>().text = facts[factIndex];
        GameObject.Find("popUpTitleFacts").GetComponent<Text>().text = $"{planetName} Facts";

        SetUpPopUpFact();
    }

    public void ClosePopUpFact()
    {
        PopUpFacts.SetActive(false);
    }

    public void SetUpPopUpFact()
    {
        if (factIndex == 0)
        {
            PopUpFacts.GetComponentsInChildren<Button>()[2].interactable = false;
        }
        else
        {
            PopUpFacts.GetComponentsInChildren<Button>()[2].interactable = true;
        }

        if (factIndex == (facts.Count - 1))
        {
            PopUpFacts.GetComponentsInChildren<Button>()[1].interactable = false;

        }
        else
        {
            PopUpFacts.GetComponentsInChildren<Button>()[1].interactable = true;

        }


        GameObject.Find("currentFact").GetComponent<Text>().text = $"{(factIndex + 1)}";

        GameObject.Find("totalFacts").GetComponent<Text>().text = $" / {(facts.Count - 1)}";
        GameObject.Find("popUpContentFacts").GetComponent<Text>().text = facts[factIndex];
    }

    public void NextFact()
    {
  
        if (factIndex < facts.Count - 2)
        {
            factIndex++;
            SetUpPopUpFact();
        }
    }

    public void PreviousFact()
    {
      //  GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"Prev clicked \n";

        if (factIndex > 1)
        {
            factIndex--;
            SetUpPopUpFact();
        }
    }

    

}
