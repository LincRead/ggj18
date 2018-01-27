using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [HideInInspector]
    public int zoomLevel = 3;

    public float zoomTweenTime = 1f; 

    CameraPixel _pixelSettings;
    
	void Start ()
    {
        _pixelSettings = GetComponent<CameraPixel>();
	}
	
	void Update ()
    {
        HandleDebugInput();
	}

    void HandleDebugInput()
    {
        if(Input.GetKey(KeyCode.Alpha4))
        {
            ChangeZoomLevel(1);
        }

        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ChangeZoomLevel(2);
        }

        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ChangeZoomLevel(3);
        }


        else if (Input.GetKey(KeyCode.Alpha1))
        {
            ChangeZoomLevel(4);
        }
    }

    void ChangeZoomLevel(int zoomLevel)
    {
        LeanTween.value(gameObject, _pixelSettings.pixelScale, zoomLevel, zoomTweenTime).setOnUpdate((float val) => 
        {
            _pixelSettings.pixelScale = val;
        });
    }
}
