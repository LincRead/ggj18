using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPixel : MonoBehaviour
{
    [Range(.5f, 4f)]
    public float pixelScale = 1;

    private int pixelsPerUnit = 100;
    private float halfScreen = 0.5f;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographic = true;
    }

    void Update()
    {
        _camera.orthographicSize = Screen.height * ((halfScreen / pixelsPerUnit) / pixelScale);
    }
}