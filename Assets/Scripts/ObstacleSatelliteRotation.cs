using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSatelliteRotation : MonoBehaviour {

    public float rotateSpeed;
    Transform parentTransform;
    public GameObject satelitePrefab;

    public const int MIN_SATELITES = 10;
    public const int MAX_SATELITES = 30;
    public const int MIN_ORBIT_RANGE = -100;
    public const int MAX_ORBIT_RANGE = 100;
    public const int MIN_ORBIT_SPEED = 5;
    public const int MAX_ORBIT_SPEED = 15;

    // Use this for initialization
    void Start () {
        parentTransform = this.transform;
        SetupSatelites();
	}

    private void SetupSatelites()
    {
        int numSatelites = UnityEngine.Random.Range(MIN_SATELITES, MAX_SATELITES);
        for (int i = 0; i < numSatelites; i++)
        {
            GameObject go = Instantiate(satelitePrefab, new Vector3(transform.position.x + UnityEngine.Random.Range(MIN_ORBIT_RANGE, MAX_ORBIT_RANGE), transform.position.y + UnityEngine.Random.Range(MIN_ORBIT_RANGE, MAX_ORBIT_RANGE)),
                                                    Quaternion.identity, this.transform);
            rotateSpeed = UnityEngine.Random.Range(MIN_ORBIT_SPEED, MAX_ORBIT_SPEED);
            go.name = rotateSpeed.ToString();

        }
    }

    // Update is called once per frame
    void Update () {
        foreach(Transform transform in this.GetComponentsInChildren<Transform>())
        {
            if (transform.gameObject.name.Contains("S"))
                continue;
            rotateSpeed = float.Parse(transform.gameObject.name);
            transform.RotateAround(parentTransform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
        }
    }
}
