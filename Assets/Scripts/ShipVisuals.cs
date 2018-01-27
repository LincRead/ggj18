using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVisuals : MonoBehaviour {

    private Animator _animator;

	void Start ()
    {
        _animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        HandleDebugInput();
	}

    void HandleDebugInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ActivateLeftEngine();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ActivateRightEngine();
        }
    }

    public void ActivateLeftEngine()
    {
        _animator.Play("left");
    }

    public void ActivateRightEngine()
    {
        _animator.Play("right");
    }
}
