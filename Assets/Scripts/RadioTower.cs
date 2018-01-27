using System.Collections;
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

    public void LaunchSignal(SignalCommand sigCommand)
    {
        if (canSendSignal)
        {
            switch (sigCommand)
            {
                case SignalCommand.LEFT:
                    if (LeftSignal)
                        Instantiate(LeftSignal, this.transform);
                    break;
                case SignalCommand.RIGHT:
                    if (RightSignal)
                        Instantiate(RightSignal, this.transform);
                    break;
                case SignalCommand.SHIELD:
                    if (ShieldSignal)
                        Instantiate(ShieldSignal, this.transform);
                    break;
            }

            _animator.Play("send");
            float time = _animator.GetCurrentAnimatorStateInfo(0).length;
            canSendSignal = false;
            Invoke("RemoveCoolDown", time);
        }
    }

    void RemoveCoolDown()
    {
        canSendSignal = true;
    }
}
