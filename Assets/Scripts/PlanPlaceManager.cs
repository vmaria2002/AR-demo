using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlanPlaceManager : MonoBehaviour
{
    public GameObject[] flowes;
    public ARSession sessionOrigin;
    public ARPlaneManager planeManager;

    void Update()
    {
        // Check if there is a touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Get all detected planes
                var planes = planeManager.trackables;

                foreach (var plane in planes)
                {
                    if (plane != null && plane.gameObject.activeSelf)
                    {
                        // Get the center of the plane
                        Vector3 planeCenter = plane.center;

                        // Convert plane center to world position
                        Vector3 worldPosition = plane.transform.TransformPoint(planeCenter);

                        // Instantiate a random flower at the plane center
                        int randomIndex = Random.Range(0, flowes.Length);
                        Instantiate(flowes[randomIndex], worldPosition, Quaternion.identity);

                        // Exit after placing the object on the first active plane
                        break;
                    }
                }
            }
        }
    }
}
