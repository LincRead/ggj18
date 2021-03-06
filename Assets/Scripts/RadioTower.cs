﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : MonoBehaviour {

    public GameObject LeftSignal;
    public GameObject RightSignal;
    public GameObject ShieldSignal;

    public AudioSource audio_sendSound;

    public float cooldown = 0.5f;

    public bool canSendSignal = false;

    Animator _animator;

    private SignalCommand nextSignalToSend;

	void Start ()
    {
        _animator = GetComponent<Animator>();
        Invoke("Activate", 3.5f);
        audio_sendSound = GetComponent<AudioSource>();
	}

    void Activate()
    {
        Invoke("Activated", .4f);
        _animator.Play("activate");
    }

    void Activated()
    {
        canSendSignal = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(WorldManager.instance.enteredFinishPlanet || WorldManager.instance.gameover)
        {
            canSendSignal = false;
            return;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            LaunchSignal(SignalCommand.LEFT);
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            LaunchSignal(SignalCommand.RIGHT);
        else if (Input.GetKeyUp(KeyCode.Space))
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
            nextSignalToSend = sigCommand;

            _animator.Play("send");

            audio_sendSound.Play();

            Invoke("RemoveCoolDown", cooldown);

            canSendSignal = false;

            Invoke("FireSignal", 0.35f);
        }
    }

    void FireSignal()
    {
        switch (nextSignalToSend)
        {
            case SignalCommand.LEFT:
                if (LeftSignal)
                    Instantiate(LeftSignal, this.transform.position + new Vector3(0.05f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
            case SignalCommand.RIGHT:
                if (RightSignal)
                    Instantiate(RightSignal, this.transform.position + new Vector3(0.05f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
            case SignalCommand.SHIELD:
                if (ShieldSignal)
                    Instantiate(ShieldSignal, this.transform.position + new Vector3(0.05f, 0.0f, 0.0f), Quaternion.identity, this.transform);
                break;
        }
    }

    void RemoveCoolDown()
    {
        canSendSignal = true;
    }
}
