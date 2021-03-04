using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

   public List<string> hints = new List<string>() { "Wait for all the players to enter the game before starting" };

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
        GameObject.Find("PopUpButton").GetComponent<Text>().text = button;

    }
    public void ClosePopUp()
    {
        PopUpStandar.SetActive(false);
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
      if(hintIndex == 0)
        {
            GameObject.Find("ButtonPrevHint").GetComponent<Button>().interactable = false;
        } else  {
            GameObject.Find("ButtonPrevHint").GetComponent<Button>().interactable = true;
        }  

      if(hintIndex == hints.Count - 1)
        {
            GameObject.Find("ButtonNextHint").GetComponent<Button>().interactable = false;

        } else {
            GameObject.Find("ButtonNextHint").GetComponent<Button>().interactable = true;

        }
        Debug.Log($"buttons  ok {hints}");
       
        GameObject.Find("currentHint").GetComponent<Text>().text = $"{hintIndex+1}";
        GameObject.Find("totalHints").GetComponent<Text>().text = $"/ {hints.Count}";
        GameObject.Find("popUpContentHints").GetComponent<Text>().text = hints[hintIndex];
        GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"{hints[hintIndex]} \n";

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

        SetHints(GameManager.runningLevel.getHint());
        PopUpHints.SetActive(true);
        SetUpPopUpHint();
    }


    public void SetHints(List<string> hintsFromLevel) {
    

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
       if(!TopMenu.activeSelf)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }

   

}
