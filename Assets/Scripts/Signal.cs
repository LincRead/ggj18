using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignalCommand { LEFT, RIGHT, SHIELD }
public class Signal : MonoBehaviour {

    public float speed;
    public SignalCommand signalCommand;

    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;

    float m_Red, m_Blue, m_Green;

    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 currPosition = transform.position;
        Vector3 shipPosition = WorldManager.instance.ship.transform.position;
        transform.position = Vector3.MoveTowards(currPosition, shipPosition, speed * Time.deltaTime);
	}

    public void DestroyAfterCommand() {
        Destroy(this);
    }
}
