using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class ARController : MonoBehaviour
{

    private List<TrackedPlane> m_NewTrackedPlanes = new List<TrackedPlane>();

    public GameObject GridPrefab;
    public GameObject Brush;

    public GameObject ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check session status
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        Session.GetTrackables<TrackedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        //Create a grid for tracked planes
        for(int i =0; i<m_NewTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);
            grid.GetComponent<GridVisual>().Initialize(m_NewTrackedPlanes[i]);
        }

        //check if user touches screen

        Touch touch;
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y,TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            //place object ontop of plane
            var paint = Instantiate(Brush, hit.Pose.position, hit.Pose.rotation);

            //create anchor
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            paint.transform.position = hit.Pose.position + new Vector3(0,.2f,0);
            paint.transform.rotation = hit.Pose.rotation;

            Vector3 cameraPosition = ARCamera.transform.position;

            cameraPosition.y = hit.Pose.position.y;

            paint.transform.LookAt(cameraPosition, paint.transform.up);

            paint.transform.parent = anchor.transform;

            
        }
    }
}
