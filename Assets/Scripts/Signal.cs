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
        setColour(signalCommand);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, WorldManager.instance.ship.transform.position, speed * Time.deltaTime);
	}

    public void DestroyAfterCommand() {
        Destroy(this);
    }

    public void setColour(SignalCommand signalCommand) {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        switch (signalCommand)
        {
            case SignalCommand.LEFT:
                Debug.Log("setColourRed");
                m_SpriteRenderer.color = Color.red;
                break;
            case SignalCommand.RIGHT:
                Debug.Log("SetColourGreen");
                m_SpriteRenderer.color = Color.green;
                break;
            case SignalCommand.SHIELD:
                Debug.Log("SetClourBlue");
                m_SpriteRenderer.color = Color.black;
                break;
        }
}
