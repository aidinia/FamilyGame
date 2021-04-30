using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    public List<string> hints = new List<string>() { "Wait for all the players to enter the game before starting", "some hint 2", "hint 3" };

    public GameObject PopUpStandar;
    public GameObject PopUpOptions;
    public GameObject PopUpHints;
    public GameObject TopMenu;

    private int hintIndex = 0;

    //-------------------------------STandar
    public void SetPopUP(string title, string message, string button)
    {
        PopUpStandar.SetActive(true);
        GameObject.Find("popUpTitle").GetComponent<Text>().text = title;
        GameObject.Find("popUpContent").GetComponent<Text>().text = message;
    }
    public void ClosePopUp()
    {
        GameObject.Find("PopUp").SetActive(false);
    }

    public void OpenPopUp()
    {
        PopUpStandar.SetActive(true);


    }

    //---------------------------HInts
    public void ClosePopUpHint()
    {
        PopUpHints.SetActive(false);
    }

    public void SetUpPopUpHint()
    {

        if (hintIndex == 0)
        {

            PopUpHints.GetComponentsInChildren<Button>()[2].interactable = false;

        }
        else
        {
            PopUpHints.GetComponentsInChildren<Button>()[2].interactable = true;
        }

        if (hintIndex == hints.Count - 1)
        {
            PopUpHints.GetComponentsInChildren<Button>()[1].interactable = false;

        }
        else
        {
            PopUpHints.GetComponentsInChildren<Button>()[1].interactable = true;

        }

        GameObject.Find("currentHint").GetComponent<Text>().text = $"{hintIndex + 1}";
        GameObject.Find("totalHints").GetComponent<Text>().text = $"/ {hints.Count}";

        GameObject.Find("popUpContentHints").GetComponent<Text>().text = hints[hintIndex];


    }

    public void NextHint()
    {
        hintIndex++;
        SetUpPopUpHint();
    }

    public void PreviousHint()
    {
        hintIndex--;

        SetUpPopUpHint();

    }

    public void OpenPopUpHint()
    {
        PopUpHints.SetActive(true);

        SetHints(GameManager.runningLevel.getHint());
        SetUpPopUpHint();
    }


    public void SetHints(List<string> hintsFromLevel)
    {


        this.hints = hintsFromLevel;
    }


    //-----------------------------Options
    public void CloseOptions()
    {
        PopUpOptions.SetActive(false);
    }

    public void OpenOptions()
    {
        Debug.Log("click");
        PopUpOptions.SetActive(true);
        GameObject.Find("PopUpOKButtonOptions").GetComponent<Button>().onClick.AddListener(CloseOptions);



    }

    public void CloseMenu()
    {
        //var topPosition = TopMenu.GetComponent<RectTransform>();
        //while (topPosition.position.x > 150)
        //{
        //    topPosition.position = new Vector3(topPosition.position.x + 1, topPosition.position.y, topPosition.position.z);
        //}

        TopMenu.SetActive(false);
    }
    public void OpenMenu()
    {
        // var topPosition = TopMenu.GetComponent<RectTransform>();
        //while (topPosition.position.x < 0)
        // {
        //     topPosition.position = new Vector3(topPosition.position.x-1, topPosition.position.y, topPosition.position.z);
        // }
        TopMenu.SetActive(true);


    }

    public void MenuButton()
    {
        var topPosition = TopMenu.GetComponent<RectTransform>();
        if (!TopMenu.activeSelf)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }



}
