using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : MonoBehaviour {

    public GameObject LeftSignal;
    public GameObject RightSignal;
    public GameObject ShieldSignal;

    public bool canSendSignal;

    Animator _animator;

    private SignalCommand nextSignalToSend;

	// Use this for initialization
	void Start () {
        canSendSignal = true;
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            LaunchSignal(SignalCommand.LEFT);
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            LaunchSignal(SignalCommand.RIGHT);
        else if (Input.GetKeyUp(KeyCode.Space))
            LaunchSignal(SignalCommand.SHIELD);
	}

    public void LaunchSignal(SignalCommand sigCommand)
    {
        if (canSendSignal)
        {
            nextSignalToSend = sigCommand;

            _animator.Play("send");

            Invoke("RemoveCoolDown", 0.9f);

            canSendSignal = false;

            Invoke("FireSignal", 0.7f);
        }
    }

    void FireSignal()
    {
        switch (nextSignalToSend)
        {
            case SignalCommand.LEFT:
                if (LeftSignal)
                    Instantiate(LeftSignal, this.transform.position + new Vector3(0.1f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
            case SignalCommand.RIGHT:
                if (RightSignal)
                    Instantiate(RightSignal, this.transform.position + new Vector3(0.1f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
            case SignalCommand.SHIELD:
                if (ShieldSignal)
                    Instantiate(ShieldSignal, this.transform.position + new Vector3(0.1f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
        }
    }

    void RemoveCoolDown()
    {
        canSendSignal = true;
    }
}
