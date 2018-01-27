using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {

    Vector3 location;
    float mass;
    float radius;
    float gravWellRadius;

    public Planet(Vector3 location, float mass, float radius) {
        this.location = location;
        this.mass = mass;
        this.radius = radius;
        this.gravWellRadius = mass * radius;
    }

    public void Update(Transform shipTransform) {
        Debug.Log("Planet:: Update- ship in range: "  + IsSpaceshipInGravWell(shipTransform.position));
        if (IsSpaceshipInRadius(shipTransform.position))
            Debug.LogAssertion("SHIP IS DEAD");

        if (IsSpaceshipInGravWell(shipTransform.position))
            PullShip(shipTransform.position);
    }

    public bool IsSpaceshipInGravWell(Vector3 spaceshipPos) {
        if (Vector3.Distance(spaceshipPos, location) <= gravWellRadius)
            return true;
        return false;
    }

    bool IsSpaceshipInRadius(Vector3 spaceshipPos)
    {
        if (Vector3.Distance(spaceshipPos, location) <= radius)
            return true;
        return false;
    }

    void PullShip(Vector3 shipTransform)
    {
        Vector2 gravVelocity = new Vector2(0, Mathf.Clamp((mass * radius) * (location.y - shipTransform.y), -5, 5));
        Debug.Log("Pulling ship: " + gravVelocity.ToString());
        PlanetController.PullShip(gravVelocity, shipTransform);
    }
}
