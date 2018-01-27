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
       shipTran.position += Vector3.left * 0.01f;

        if (Input.GetKeyDown("down"))
        {
            Debug.Log("down");
            shipTran.position += Vector3.up * 0.5f;
        }

        if (Input.GetKeyDown("up"))
        {
            Debug.Log("up");
            shipTran.position += Vector3.down * 0.5f;
        }


    }

    #region

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

    public void receiveSignal(SignalCommand signalCommand) {
        switch (signalCommand) {

            case SignalCommand.LEFT:
                Debug.Log("left");
                break;
            case SignalCommand.RIGHT:
                Debug.Log("right");
                break;
            case SignalCommand.SHIELD:
                Debug.Log("shield");
                break;
        }
    }
    #endregion

}
