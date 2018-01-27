﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : MonoBehaviour {

    public GameObject LeftSignal;
    public GameObject RightSignal;
    public GameObject ShieldSignal;

    public bool canSendSignal;

    Animator _animator;

	// Use this for initialization
	void Start () {
        canSendSignal = true;
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
                LaunchSignal(SignalCommand.LEFT);
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                LaunchSignal(SignalCommand.RIGHT);
            if (Input.GetKeyUp(KeyCode.Space))
                LaunchSignal(SignalCommand.SHIELD);
	}

    public void LaunchSignal(int sigCommand)
    {
        LaunchSignal((SignalCommand)sigCommand);
    }

    public void LaunchSignal(SignalCommand sigCommand)
    {
        if (canSendSignal)
        {
            canSendSignal = false;
            switch (sigCommand)
            {
                case SignalCommand.LEFT:
                    if (LeftSignal)
                        Instantiate(LeftSignal, this.transform.position, Quaternion.identity, this.transform);
                    break;
                case SignalCommand.RIGHT:
                    if (RightSignal)
                        Instantiate(RightSignal, this.transform.position, Quaternion.identity, this.transform);
                    break;
                case SignalCommand.SHIELD:
                    if (ShieldSignal)
                        Instantiate(ShieldSignal, this.transform.position, Quaternion.identity, this.transform);
                    break;
            }

            _animator.Play("send");
            float time = _animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("RemoveCoolDown", time);
        }
    }

    void RemoveCoolDown()
    {
        canSendSignal = true;
    }
}
