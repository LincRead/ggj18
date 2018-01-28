using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarManager : MonoBehaviour {

    public static RadarManager instance;

    public GameObject planetObjPrefab;
    public GameObject obstacleObjPrefab;

    // Use this for initialization
    void Awake () {
        instance = this;
	}

    public void AddPlanet(Transform _transform)
    {
        GameObject go = Instantiate(planetObjPrefab, gameObject.transform, false) as GameObject;
        MinimapObject minimapob = go.GetComponent<MinimapObject>();
        minimapob.SetTransformRef(_transform);
    }

    public void AddObstacle(Transform _transform)
    {
        GameObject go = Instantiate(obstacleObjPrefab, gameObject.transform, false) as GameObject;
        MinimapObject minimapob = go.GetComponent<MinimapObject>();
        minimapob.SetTransformRef(_transform);
    }
}
