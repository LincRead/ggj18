using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignalCommand { LEFT, RIGHT, SHIELD }
public class Signal : MonoBehaviour {

    public float speed;
    public SignalCommand signalCommand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    //transform.position = Vector3.MoveTowards(transform.position, )
	}
}
