using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {
    Vector2 veocity = Vector2.zero;
    public float thrustPower = 1f;
    public float initVelocityX = 1f;
    public float maxSpeed = 3f;
    public float shieldPower = 10f;
    public float shieldUseCost = 1f;
    public float shieldActiveTime = 1f;

    private ShipVisuals _shipVisuals;
    private ShieldVisuals shieldVisuals;
    private PlanetController pc;
    private bool isShieldActive = false;

    public AudioSource audio_explosion;
    public AudioSource audio_thrust;
    public AudioSource audio_shieldActivate;
    public AudioSource audio_shieldLowPower;
    public AudioSource audio_shipOOB;

    public GameObject explosion;

    public GameObject finalPlanet;

    // Use this for initialization
    private void Start () {
        pc = GameObject.FindObjectOfType<PlanetController>();
        transform.localScale = new Vector3(0,0,0);
        _shipVisuals = GetComponent<ShipVisuals>();
        shieldVisuals = GetComponentInChildren<ShieldVisuals>();

        audio_explosion = GetComponent<AudioSource>();
        audio_thrust = GetComponent<AudioSource>();

        Invoke("Init", 0f);
    }

    private void Init()
    {
        veocity.x = initVelocityX;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 2);
    }

    private void Update()
    {
        if(veocity.x != 0 || veocity.y != 0)
        {
            transform.position += new Vector3(veocity.x * Time.deltaTime, veocity.y * Time.deltaTime, 0.0f);

            if(transform.position.y > 2.9f || transform.position.y < - 2.9f || transform.position.x > finalPlanet.transform.position.x)
            {
                audio_shipOOB.Play();
                Die();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.gameObject.tag == "Planet")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Die();
        }

        if (collision.gameObject.tag == "Obstacle" && !isShieldActive)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Die();
        }
        else if (collision.gameObject.tag == "Obstacle" && isShieldActive)
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            audio_explosion.Play();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Signal hits Planet
        if (collision.gameObject.tag == "Signal")
        {
            receiveSignal(collision.gameObject.GetComponent<Signal>().signalCommand);
            Destroy(collision.gameObject);
        }

        //Ship hits Finishing Planet
        if (collision.gameObject.tag == "Finish")
        {
            Win();
        }
    }

    void Die()
    {
        audio_explosion.Play();
        veocity.x = 0;
        veocity.y = 0;
        GetComponent<Collider2D>().enabled = false;
        WorldManager.instance.GameOver();
        GetComponent<SpriteRenderer>().enabled = false;

    }

    void Win()
    {
        WorldManager.instance.enteredFinishPlanet = true;

        float time = 2f;
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), time);
        Invoke("Stop", time);
    }

    void Stop()
    {
        veocity.x = 0;

        WorldManager.instance.won = true;
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
                if ((shieldPower - shieldUseCost) >= 0)
                {
                    audio_shieldActivate.Play();
                    isShieldActive = true;
                    shieldVisuals.ActivateShield(shieldActiveTime);
                    shieldPower -= shieldUseCost;
                    Invoke("TurnOffShield", shieldActiveTime);                  
                }
                else
                {
                    audio_shieldLowPower.Play();
                }
                break;
        }
    }

    void TurnOffShield()
    {
        isShieldActive = false;
    }
}

