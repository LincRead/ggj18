using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if (WorldManager.instance.won)
        {
            _image.enabled = true;
        }

        else
        {
            _image.enabled = false;
        }
    }
}
