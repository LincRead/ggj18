using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {
    Vector2 veocity = Vector2.zero;
    public float thrustPower = 1f;
    public float velocityX = 1f;
    public float maxSpeed = 3f;

    private ShipVisuals _shipVisuals;

    // Use this for initialization
    private void Start () {
        veocity.x = velocityX;

        _shipVisuals = GetComponent<ShipVisuals>();
    }

    private void Update() {
        
        /*if (Input.GetKeyDown("down"))
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
        }*/

        transform.position += new Vector3(veocity.x * Time.deltaTime, veocity.y * Time.deltaTime, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.gameObject.tag == "planet")
        {
            Debug.Log("explode");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            receiveSignal(collision.gameObject.GetComponent<Signal>().signalCommand);
            Destroy(collision.gameObject);
        }
    }

    public void receiveSignal(SignalCommand signalCommand)
    {
        switch (signalCommand)
        {
            case SignalCommand.LEFT:

                if (veocity.y < maxSpeed)
                {
                    _shipVisuals.ActivateRightEngine();
                    veocity.y += thrustPower;
                }

                if (veocity.y > maxSpeed)
                {
                    veocity.y = maxSpeed;
                }

                break;

            case SignalCommand.RIGHT:

                if (veocity.y > -maxSpeed)
                {
                    _shipVisuals.ActivateLeftEngine();

                    veocity.y -= thrustPower;

                }

                if(veocity.y < - maxSpeed)
                {
                    veocity.y = -maxSpeed;
                }

                break;

            case SignalCommand.SHIELD:
                Debug.Log("shield");
                break;
        }
    }

}

