using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{


    List<string> items;
    private readonly Func<bool> Goal;
    public List<string> hints;

    int difficulty;
    string lvlName;
    public static bool pass = false;
    int hintIndex = 0;

    public static List<string> currentItems = new List<string>();

    public Level(string lvlNm, List<string> items, List<string> hintList)
    {
        this.lvlName = lvlNm;
        this.items = items;
        this.hints = hintList;
    }


    public bool isFinish()
    {
        return pass;
    }



    public List<string> getHint()
    {
        List<string> listOfHints = new List<string>();
        for (int i = 0; i < hintIndex; i++)
        {
            listOfHints.Add(hints[i]);
        }
        if (hintIndex < hints.Count - 1)
        {
            hintIndex++;
        }
     //   GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"{listOfHints} \n";

        return listOfHints;
    }

    public List<string> getItems()
    {
        return this.items;
    }

    public List<GameObject> getItemsFromString(List<string> itemsNames)

    {
        List<GameObject> itemsObjects = new List<GameObject>();
        foreach (var item in itemsNames)
        {
            itemsObjects.Add(GameObject.Find(item));
        }
        return itemsObjects;
    }

    public void LoadLevel()
    {

        //Load Scene
        PhotonNetwork.LoadLevel(lvlName);   

        // Load Items
            foreach (string itemName in items)
            {
            if (currentItems.IndexOf(itemName) <0)
                {
                    currentItems.Add(itemName);
                }
            }

        //Load hints
        GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().SetHints(getHint());

    }

    public void destroyPrevLevel()
    {
        foreach (var item in items)
        {
            Destroy(GameObject.Find(item));

        }
    }

}
