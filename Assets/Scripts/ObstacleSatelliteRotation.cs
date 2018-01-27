using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSatelliteRotation : MonoBehaviour {

    public float rotateSpeed;
    Transform parentTransform;
	// Use this for initialization
	void Start () {
        parentTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        foreach(Transform transform in this.GetComponentsInChildren<Transform>())
        {
            transform.RotateAround(parentTransform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
        }
    }
}
