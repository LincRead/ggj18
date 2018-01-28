using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {

    Transform _t;

	// Use this for initialization
	void Start () {
        _t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camp = Camera.main.transform.position;
        _t.transform.position = new Vector3(camp.x, camp.y, 0);
    }
}
