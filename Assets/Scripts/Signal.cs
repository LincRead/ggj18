using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignalCommand { LEFT, RIGHT, SHIELD }
public class Signal : MonoBehaviour
{

    public float speed;
    public SignalCommand signalCommand;

    SpriteRenderer m_SpriteRenderer;

    public Color signalColor;

    // Use this for initialization
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = signalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldManager.instance.gameover || WorldManager.instance.enteredFinishPlanet)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 currPosition = transform.position;
        Vector3 shipPosition = WorldManager.instance.ship.transform.position;
        transform.position = Vector3.MoveTowards(currPosition, shipPosition, speed * Time.deltaTime);
    }

    public void DestroyAfterCommand()
    {
        Destroy(this);
    }
}
