using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
    public bool directionBoolean;
    public int counter;

    // Use this for initialization
    void Start () {
        directionBoolean = true;
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Bounce();
    }

    public void Bounce()
    {
        if (directionBoolean) {
            transform.Translate(Vector3.left * Time.deltaTime);
            counter += 1;
            if (counter > 10) {
                directionBoolean = false;
            }

        } else if (directionBoolean == false) {
            transform.Translate(Vector3.right * Time.deltaTime);
            counter -= 1;
            if (counter < 0) {
                directionBoolean = true;
            }
        }
    }
}
