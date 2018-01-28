using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapObject : MonoBehaviour {

    Transform _t;
    Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetTransformRef(Transform t)
    {
        _t = t;
    }

	void Update ()
    {
	    if(_t == null || IsOutsideMap())
        {
            _image.enabled = false;
        }
       

        else
        {
            _image.enabled = true;
            UpdatePosition();
        }
	}

    bool IsOutsideMap()
    {
        return false;
    }

    void UpdatePosition()
    {

    }
}
