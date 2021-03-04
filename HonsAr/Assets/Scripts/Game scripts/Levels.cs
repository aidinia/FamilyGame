using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    public static List<List<Level>> AllLevels = new List<List<Level>> {
          new List<Level>(){
                        new Level("Planets",
                            new List<string>(){"Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto"},
                            new List<string>(){ "Find the planets in the Sky", "When you touch a planet it will move to the centre of the room","The earth is round, so planets can be up or down"})
        }
          
          

};


    public static List<Level> GetLevels()
    {

        var game = new List<Level>();
       // var random = Random.Range(0, AllLevels[0].Count);
        game.Add(AllLevels[0][0]);
       
        return game;
    }

}

