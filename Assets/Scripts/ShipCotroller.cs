using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCotroller : MonoBehaviour {

    private Rigidbody2D rb;

    #region

    private void FixedUpdate()
    {

    }

    #endregion

    #region


    // Use this for initialization
    private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update() {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = 1;

        ThrustUpDown(yAxis);
        ThrustContant(xAxis);
    }

    #endregion

    #region Maneuvering API

    private void ClampVelocity() {

    }

    private void ThrustUpDown(float amount) {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    private void ThrustContant(float amount) {
        Vector2 force = transform.right * 1;
        rb.AddForce(force);
    }

    #endregion

}
