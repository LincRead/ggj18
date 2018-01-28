using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldVisuals : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        animator.Play("shield");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateShield(float shieldTime)
    {
        sr.enabled = true;
        Invoke("DeactivateShield", shieldTime);
    }

    void DeactivateShield()
    {
        sr.enabled = false;
    }
}
