
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class objectScript : MonoBehaviour
{
    public GameObject square;
    public GameObject arCam;
    public GameObject spawnedObject { get; private set; }

    ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    static List<GameObject> objects  = new List<GameObject>();




    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    } 

    public void Update()
    {
        if(Input.touchCount > 0)
        {
            bool last = false;
            var index = -1;
            Vector2 touchPosition = Input.GetTouch(0).position;

            //if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            //{
            //    // Raycast hits are sorted by distance, so the first one
            //    // will be the closest hit.   
            //    var hitPose = s_Hits[0].pose;
                spawnedObject = Instantiate(square, arCam.transform.position, arCam.transform.rotation);


                //    for (var i = 0; i < objects.Count; i++)
                //    {
                //        var obj = objects[i];
                //        var dif = hitPose.position - obj.transform.position;
                //        if(dif.x < 0.1 && dif.y < 0.1 && dif.z < 0.1)
                //        {
                //            last = true;
                //            index = i;
                //            break;
                //        }
                //    }

                //  if (last && index != -1)
                //    {
                //        var touchObj = objects[index];
                //        index = -1;
                //        touchObj.transform.position = hitPose.position;
                //    }
                //    else {
                //        Vector3 cubePosition = hitPose.position + new Vector3(0, 1, 0);
                //        spawnedObject = Instantiate(square, cubePosition, hitPose.rotation);

                //        var anchor = GetComponent<ARAnchorManager>().AddAnchor(new Pose(cubePosition, hitPose.rotation));
                //        spawnedObject.transform.parent = anchor.transform;
                //        ARCloudManagerANchors.QueueAnchor(anchor);

                //        //Call SetColor using the shader property name "_Color" and setting the color to red
                //        var cubeRenderer = spawnedObject.GetComponent<Renderer>();
                //        cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
                //        objects.Add(spawnedObject);

                //    }
            //}
               
            }
        }

    public void RecreatePlacement()
    {

    }

    }

