using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{

    public float lat = 51.503926f;
    public float lon = -0.11748f;

    public static int planets = 0;
    // public Camera cam;

    // Start is called before the first frame update
    void Awake()
    {

        while (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        StartCoroutine(StartLocation());

        var planetName = this.name.Replace("(Clone)", "");
        PlanetName planet = (PlanetName)Enum.Parse(typeof(PlanetName), planetName.ToUpper());
        Vector3 planetLocation = CelestialCoordinates.CalculateHorizontalCoordinatesPlanets(lat, lon, planet, DateTime.Now);
      
        Vector3 cartesianLocation = Quaternion.Euler(-planetLocation.x, planetLocation.y, 0) * new Vector3(0, 0, planetLocation.z);


        //float x = (float)(planetLocation.z * Math.Cos(planetLocation.x) * Math.Cos(planetLocation.y));
        //float y = (float)(planetLocation.z * Math.Cos(planetLocation.x) * Math.Sin(planetLocation.y));
        //float z = (float)(planetLocation.z * Math.Sin(planetLocation.x));

        //Vector3 cartesianLocation = new Vector3(x, y, z);
        while (Vector3.Distance(cartesianLocation, Vector3.zero) > 1.5)
        {
            cartesianLocation = Vector3.MoveTowards(cartesianLocation, Vector3.zero, 1);
        }
        this.transform.position = cartesianLocation;


        // ---------------This doesn't have to be on every place as the planets are loaded in each phone... ?
        GameObject.Find("DebugCanvas").GetComponent<Text>().text += $"Planet {planet} loaded at {cartesianLocation} \n";


    }
    private void Start()
    {

    }
    private void Update()
    {
        //if(Input.location.status != LocationServiceStatus.Running)
        //{
        //    StartCoroutine(StartLocation());

        //}
    }


    [PunRPC]
    private void RemovePlanet(string planet)
    {
        Debug.Log(planet);
        Level.currentItems.Remove(planet);

    }

    IEnumerator StartLocation()
    {
        //if (!Input.location.isEnabledByUser)
        //{

        //    debText.text = "Not enabled";
        //    yield break;
        //}

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }

        double longitude = Input.location.lastData.longitude;
        double latitude = Input.location.lastData.latitude;

        //lat = (float)latitude;
        //lon = (float)longitude;
        Input.location.Stop();
        StopCoroutine("Start");



    }

    public static Dictionary<string, List<string>> facts = new Dictionary<string, List<string>>()
   {
       {"Mercury", new List<string>(){"Mercury does not have any moons or rings.", "Mercury is the smallest planet.", "Mercury is the closest planet to the Sun.", "Your weight on Mercury would be 38% of your weight on Earth.", "A solar day on the surface of Mercury lasts 176 Earth days.", "A year on Mercury takes 88 Earth days.", "It’s not known who discovered Mercury." } },
       {"Venus", new List<string>(){"Venus does not have any moons or rings.","Venus is nearly as big as the Earth with a diameter of 12,104 km.","Venus is thought to be made up of a central iron core, rocky mantle and silicate crust.","A day on the surface of Venus (solar day) would appear to take 117 Earth days.","A year on Venus takes 225 Earth days.","The surface temperature on Venus can reach 471 °C." } },
       {"Mars", new List<string>(){"Mars and Earth have approximately the same landmass.", "Mars is home to the tallest mountain in the solar system.", "Only 18 missions (of 40) to Mars have been successful.","Mars has the largest dust storms in the solar system.", "On Mars the Sun appears about half the size as it does on Earth.","Pieces of Mars have fallen to Earth.", "One day Mars will have a ring.", "Sunsets on Mars are blue." } },
       {"Jupiter", new List<string>(){"Jupiter is the fourth brightest object in the solar system.", "The ancient Babylonians were the first to record their sightings of Jupiter.", "Jupiter has the shortest day of all the planets.", "Jupiter orbits the Sun once every 11.8 Earth years.","Jupiter has unique cloud features.","The Great Red Spot is a huge storm on Jupiter.", "Jupiter’s interior is made of rock, metal, and hydrogen compounds.", "Jupiter’s moon Ganymede is the largest moon in the solar system.", "Jupiter has a thin ring system." } },
       {"Saturn", new List<string>(){"Saturn is the most distant planet that can be seen with the naked eye.", "Saturn was known to the ancients, including the Babylonians and Far Eastern observers.", "Saturn is the flattest planet.", "Saturn orbits the Sun once every 29.4 Earth years.", "Saturn’s upper atmosphere is divided into bands of clouds.", "Saturn has oval-shaped storms similar to Jupiter’s.", "Saturn is made mostly of hydrogen.", "Saturn has the most extensive rings in the solar system.", "Saturn has 150 moons and smaller moonlets.", "Titan is a moon with complex and dense nitrogen-rich atmosphere.",  }},
       {"Uranus", new List<string>(){"Uranus was officially discovered by Sir William Herschel in 1781.", "Uranus turns on its axis once every 17 hours, 14 minutes.", "Uranus makes one trip around the Sun every 84 Earth years.", "Uranus is often referred to as an “ice giant” planet.", "Uranus hits the coldest temperatures of any planet.", "Uranus has two sets of very thin dark coloured rings.", "Uranus’ moons are named after characters created by William Shakespeare and Alexander Pope." } },
       {"Neptune", new List<string>(){"Neptune is the most distant planet from the Sun.","Neptune is the smallest gas giant.","A year on Neptune lasts 165 Earth years.", "Neptune is named after the Roman god of the sea.", "Neptune has 6 faint rings." } },
       {"Pluto", new List<string>(){"Pluto is named after the Roman god of the underworld.", "Pluto was reclassified from a planet to a dwarf planet in 2006.", "Pluto was discovered on February 18th, 1930 by the Lowell Observatory.", "Pluto has five known moons.", "Pluto is the largest dwarf planet.", "Pluto is one third water.", "Pluto sometimes has an atmosphere." } }
   };


}
