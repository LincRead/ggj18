using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVisuals : MonoBehaviour {

    private Animator _animator;

    public GameObject explosion;

	void Start ()
    {
        _animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        //HandleDebugInput();
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

        else if(Input.GetKeyDown(KeyCode.X))
        {
            PlayExplosion();
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

    public void ActivateShield()
    {
        _animator.Play("shield");
    }

    public void PlayExplosion()
    {
        if(explosion)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
