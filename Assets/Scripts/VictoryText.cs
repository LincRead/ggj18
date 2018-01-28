using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour {

    Text _text;

	void Start ()
    {
        _text = GetComponent<Text>();
	}
	
	void Update ()
    {
		if(WorldManager.instance.won)
        {
            _text.enabled = true;

            if(Input.GetKeyUp(KeyCode.R))
            {
                WorldManager.instance.RestartGame();
            }
        }

        else
        {
            _text.enabled = false;
        }
	}
}
