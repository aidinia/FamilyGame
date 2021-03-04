using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LightValues : MonoBehaviour
{

    public Text text;
    public ARCameraManager camManager;
    public LightValues(Text _text, ARCameraManager _cam)
    {
        text = _text;
        camManager = _cam;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = camManager.currentLightEstimation.ToString();
       
        
    }
}
