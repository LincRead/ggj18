using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dummyScript_signal : MonoBehaviour
{
    Vector2 veocity = Vector2.zero;

    // Use this for initialization
    private void Start()
    {
        veocity.x = +3f;
    }

    private void Update()
    {
        transform.position += new Vector3(veocity.x * Time.deltaTime, veocity.y * Time.deltaTime, 0.0f);
    }
}
