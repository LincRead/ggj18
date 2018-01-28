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
        float xoffset = Camera.main.transform.position.x * 1.5f;
        float yOffset = Camera.main.transform.position.y * 1.5f;
        float xBound = Camera.main.transform.position.x + xoffset;
        float yBound = Camera.main.transform.position.y + yOffset;
        if (_t.position.x < 0 - xBound || _t.position.x > xBound || _t.position.y < 0 - yBound || _t.position.y > yBound)
        {
            return true;
        }
        return false;
    }

    void UpdatePosition()
    {
        float xoffset = Camera.main.transform.position.x *  0.05f;
        float yOffset = Camera.main.transform.position.y * 0.05f;
        _t.position = new Vector3(_t.position.x - xoffset, _t.position.y - yOffset);
    }
}
