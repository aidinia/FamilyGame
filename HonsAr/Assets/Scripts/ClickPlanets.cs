using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ClickPlanets : MonoBehaviour
{

    public Camera cam;
    public GameObject PopUpFacts;
    public Button NextLevelButton;

    private List<string> facts = new List<string>();
    private int factIndex = 0;



    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            var touch = Input.GetTouch(0).position;

            //   // text.text = $"click{touch}";
            var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"Planet found : {PopUpFacts.activeSelf}";

                var selection = hit.transform;
                if (!Level.currentItems.ContainsKey(selection.name))
                {


                    if (!PopUpFacts.activeSelf && facts.Contains(selection.name))
                    {
                         OpenPopUpFacts(selection.name);
                    }
                    

                }
                else
                {

                    var viewToDestroy = GameObject.Find(selection.name);
                    GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"Planet found : {viewToDestroy}";

                    var original = (GameObject)Resources.Load(selection.name.Replace("(Clone)", ""));
                    GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"Planet found : {viewToDestroy}";

                    viewToDestroy.transform.localScale = original.transform.localScale;
                    viewToDestroy.transform.position = original.transform.localScale;

                    Level.currentItems.Remove(selection.name);
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
        GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"{facts} \n";

        Debug.Log($"Fact {planetName}");
        PopUpFacts.SetActive(true);
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
            GameObject.Find("ButtonPrevFact").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("ButtonPrevFact").GetComponent<Button>().interactable = true;
        }
        if (factIndex == facts.Count - 1)
        {
            GameObject.Find("ButtonNextFact").GetComponent<Button>().interactable = false;

        }
        else
        {
            GameObject.Find("ButtonNextFact").GetComponent<Button>().interactable = true;

        }

        GameObject.Find("currentFact").GetComponent<Text>().text = $"{factIndex + 1}";
        GameObject.Find("totalFacts").GetComponent<Text>().text = $"/ {facts.Count}";
        GameObject.Find("popUpContentFacts").GetComponent<Text>().text = facts[factIndex];
    }

    public void NextFact()
    {
        factIndex++;
        SetUpPopUpFact();
    }

    public void PreviousFact()
    {
        factIndex--;
        SetUpPopUpFact();
    }

}
