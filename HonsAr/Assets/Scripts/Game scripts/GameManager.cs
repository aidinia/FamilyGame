    using Photon.Pun;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Level> levels;
    private int currentLevel = 0;
    bool inGame = false;

    public static Level runningLevel;

    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void StartGame()
    {


        LoadLevels();
        runningLevel = levels[currentLevel];
        runningLevel.LoadLevel();
        inGame = true;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (levels[currentLevel].isFinish())
        {

            currentLevel++;
            if (currentLevel == levels.Count)
            {
               
                GameObject.Find("MainCanvasWPopUps").GetComponent<PopUp>().SetPopUP("End of Game", "Congratulations you found the treassure", "Close");


            }
            else
            {
                runningLevel = levels[currentLevel];
                runningLevel.LoadLevel();
            }

        }
        
    }




    public void LoadLevels()
    {
        levels = Levels.GetLevels();
    }


}
