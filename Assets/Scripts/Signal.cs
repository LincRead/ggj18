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
        Vector3 currPosition = transform.position;
        Vector3 shipPosition = WorldManager.instance.ship.transform.position;
        transform.position = Vector3.MoveTowards(currPosition, shipPosition, speed * Time.deltaTime);
	}

    public void DestroyAfterCommand() {
        Destroy(this);
    }
}
