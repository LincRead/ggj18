using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {
    Vector2 veocity = Vector2.zero;
    public float thrustPower = 1f;
    public float velocityX = 1f;
    public float maxSpeed = 3f;
    public float shieldPower = 10f;
    public float shieldUseCost = 1f;
    public float shieldActiveTime = 1f;

    private ShipVisuals _shipVisuals;
    private PlanetController pc;
    private bool isShieldActive = false;


    // Use this for initialization
    private void Start () {
        pc = GameObject.FindObjectOfType<PlanetController>();
        transform.localScale = new Vector3(0,0,0);
        _shipVisuals = GetComponent<ShipVisuals>();

        Invoke("Init", 1f);
    }

    private void Init()
    {
        veocity.x = velocityX;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 2);
    }

    private void Update() {
        
        transform.position += new Vector3(veocity.x * Time.deltaTime, veocity.y * Time.deltaTime, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.gameObject.tag == "Planet")
        {
            if (pc.IsWinPlanet(collision.gameObject)) ;
            //TODO: Start the win here
            else
                Debug.Log("explode"); //TODO Replace with explosion and game over
        }

        if (collision.gameObject.tag == "Obstacle" && !isShieldActive)
            Debug.Log("Explode"); //TODO Replace with explosion and game over
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
                isShieldActive = true;
                shieldPower -= shieldUseCost;
                Invoke("TurnOffShield", shieldActiveTime);
                Debug.Log("shield");
                break;
        }
    }

    void TurnOffShield()
    {
        isShieldActive = false;
    }
}

