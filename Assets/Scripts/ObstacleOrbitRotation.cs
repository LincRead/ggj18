using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOrbitRotation : MonoBehaviour {

    public float rotateSpeed;
    Transform parentTransform;
    public GameObject[] obstaclePrefabs;
    PlanetController pc;

    public const int MIN_SATELITES = 10;
    public const int MAX_SATELITES = 30;
    public int MIN_ORBIT_RANGE = -50;
    public int MAX_ORBIT_RANGE = 50;
    public const int MIN_ORBIT_SPEED = 3;
    public const int MAX_ORBIT_SPEED = 10;

    // Use this for initialization
    void Start () {
        parentTransform = this.transform;
        
        pc = GameObject.FindObjectOfType<PlanetController>();
        MIN_ORBIT_RANGE = 5 - (int)pc.planetSpacing;
        MAX_ORBIT_RANGE = (int)pc.planetSpacing - 5;
        SetupSatelites();
    }

    private void SetupSatelites()
    {
        int numSatelites = UnityEngine.Random.Range(MIN_SATELITES, MAX_SATELITES);
        for (int i = 0; i < numSatelites; i++)
        {
            GameObject go = Instantiate(obstaclePrefabs[UnityEngine.Random.Range(0, obstaclePrefabs.Length)], new Vector3(transform.position.x + UnityEngine.Random.Range(MIN_ORBIT_RANGE, MAX_ORBIT_RANGE), transform.position.y + UnityEngine.Random.Range(MIN_ORBIT_RANGE, MAX_ORBIT_RANGE)),
                                                    Quaternion.identity, this.transform);
            rotateSpeed = UnityEngine.Random.Range(MIN_ORBIT_SPEED, MAX_ORBIT_SPEED);
            string rotateDirection = UnityEngine.Random.Range(0, 10) <= 5 ? "C" : "A";
            go.name = rotateSpeed.ToString() + rotateDirection;
            go.tag = "Obstacle";

        }
    }

    // Update is called once per frame
    void Update () {
        foreach(Transform transform in this.GetComponentsInChildren<Transform>())
        {
            if (transform == parentTransform)
                continue;
            string rotateSpeedString = transform.gameObject.name.Substring(0, 1);
            rotateSpeed = float.Parse(rotateSpeedString);
            if(transform.gameObject.name.Substring(1,1) == "C")
                transform.RotateAround(parentTransform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
            else
                transform.RotateAround(parentTransform.position, new Vector3(0, 0, -1), rotateSpeed * Time.deltaTime);
            //transform.LookAt(parentTransform);
        }
    }
}
