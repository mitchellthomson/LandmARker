using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingMarker : MonoBehaviour
{
    public GameObject marker;
    
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 markerposition = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        marker.transform.position = camera.transform.position;
    }
}
