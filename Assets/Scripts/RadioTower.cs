using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : MonoBehaviour {

    public GameObject LeftSignal;
    public GameObject RightSignal;
    public GameObject ShieldSignal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            LaunchSignal(SignalCommand.LEFT);
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            LaunchSignal(SignalCommand.RIGHT);
        if (Input.GetKeyUp(KeyCode.Space))
            LaunchSignal(SignalCommand.SHIELD);
	}

    public void LaunchSignal(SignalCommand sigCommand)
    {
        switch (sigCommand)
        {
            case SignalCommand.LEFT:
                Instantiate(LeftSignal, this.transform);
                break;
            case SignalCommand.RIGHT:
                Instantiate(RightSignal, this.transform);
                break;
            case SignalCommand.SHIELD:
                Instantiate(ShieldSignal, this.transform);
                break;
        }
    }
}
