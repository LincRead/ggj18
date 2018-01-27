using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {

    private Transform shipTran;
  
    // Use this for initialization
    private void Start () {
        shipTran = GetComponent<Transform>();
	}

    private void Update() {
       // shipTran.position += Vector3.left;

        if (Input.GetKeyDown("up"))
        {
            Debug.Log("up");
            shipTran.position += Vector3.up * 1.0f;
        }

        if (Input.GetKeyDown("down"))
        {
            Debug.Log("down");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "planet")
        {
            Debug.Log("explode");
        }
        if (collision.gameObject.tag == "signal")
        {
            Debug.Log("call method action");
        }

    }

    public void receiveSignal() {

    }

}
