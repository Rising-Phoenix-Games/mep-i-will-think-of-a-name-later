using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public float minZoom, maxZoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0f && Camera.main.orthographicSize >= minZoom)
        {
            // scroll up
            Camera.main.orthographicSize -= .25f;
        }
        else if (d < 0f && Camera.main.orthographicSize <= maxZoom)
        {
            // scroll down
            Camera.main.orthographicSize += .25f;
        }

        if (Input.GetButton("Reset Camera")) {
            Camera.main.orthographicSize = 5f;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 1, 7);
        }
    }
}
