using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {
    Vector2 veocity = Vector2.zero;

    public float speed;

    // Use this for initialization
    private void Start () {
        veocity.x = +speed;
    }

    private void Update() {
      //  Debug.Log(veocity.y);
        
        if (Input.GetKeyDown("down"))
        {
            if (veocity.y > -3) {
                veocity.y -= 1f;
            }
        }
        if (Input.GetKeyDown("up"))
        {
            if (veocity.y < 3) {
                veocity.y += 1f;
            }
        }
        transform.position += new Vector3(veocity.x * Time.deltaTime, veocity.y * Time.deltaTime, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "planet")
        {
            Debug.Log("explode");
        }

        if (collision.gameObject.tag == "Signal")
        {
            Debug.Log("call method action");
            receiveSignal(collision.gameObject.GetComponent<Signal>().signalCommand);
            Destroy(collision.gameObject);
        }
    }

    public void receiveSignal(SignalCommand signalCommand)
    {
        Debug.Log("hit");

        switch (signalCommand)
        {
            case SignalCommand.LEFT:
                Debug.Log("left");
                if (veocity.y < 3)
                {
                    veocity.y += 1f;
                }
                break;
            case SignalCommand.RIGHT:
                Debug.Log("right");
                if (veocity.y > -3)
                {
                    veocity.y -= 1f;
                }
                break;
            case SignalCommand.SHIELD:
                Debug.Log("shield");
                break;
        }
    }

}

