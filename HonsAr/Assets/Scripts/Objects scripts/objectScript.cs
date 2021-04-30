
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class objectScript : MonoBehaviour
{
    public GameObject square;
    public Camera arCam;
    public GameObject spawnedObject { get; private set; }

    ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    static List<GameObject> objects = new List<GameObject>();




    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
          
           // Vector2 touchPosition = Input.GetTouch(0).position;
            //Ray ray = arCam.ScreenPointToRay(touchPosition);
            //RaycastHit hitObject;
            //if (Physics.Raycast(ray, out hitObject))
            //{

            //    var touchedObject = hitObject.collider.GetComponent<MeshCollider>();
            //    if (touchedObject == null) /// ====> This is always null ??
            //    {
                    spawnedObject = Instantiate(square, arCam.transform.position, arCam.transform.rotation);
            //    }
            //    else
            //    {
            //        touchedObject.transform.position = touchPosition;
            //    }
            //}





            //bool last = false;
            //var index = -1;
            //Vector2 touchPosition = Input.GetTouch(0).position;
            //if (m_RaycastManager.Raycast(touchPosition, s_Hits))
            //{

            //    // Raycast hits are sorted by distance, so the first one
            //    // will be the closest hit.   
            //    var hitPose = s_Hits[0].pose;


            //    for (var i = 0; i < objects.Count; i++)
            //    {
            //        var obj = objects[i];
            //        var dif = hitPose.position - obj.transform.position;
            //        if (dif.x < 0.1 && dif.y < 0.1 && dif.z < 0.1)
            //        {
            //            last = true;
            //            index = i;
            //            break;
            //        }
            //    }


            //    if (last && index != -1)
            //    {
            //        var touchObj = objects[index];
            //        index = -1;
            //        touchObj.transform.position = hitPose.position;
            //    }
            //    else
            //    {
            //        Vector3 cubePosition = hitPose.position + new Vector3(0, 1, 0);
            //        spawnedObject = Instantiate(square, cubePosition, hitPose.rotation);
            //        objects.Add(spawnedObject);

            //    }
            //}



                //        //Call SetColor using the shader property name "_Color" and setting the color to red
                //        var cubeRenderer = spawnedObject.GetComponent<Renderer>();
                //        cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
                //        objects.Add(spawnedObject);

                //    }
                //}

            }
    }

   

}

