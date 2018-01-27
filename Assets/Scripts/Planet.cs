using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {

    [HideInInspector]
    public Vector3 location;
    float mass;
    [HideInInspector]
    public float radius;
    float gravWellRadius;
    bool goalPlanet;

    public Planet(Vector3 location, float mass, float radius, bool goalPlanet = false) {
        this.location = location;
        this.mass = mass;
        this.radius = radius;
        this.gravWellRadius = mass * radius;
        this.goalPlanet = goalPlanet;
    }

    public void Update(Transform shipTransform) {
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
        PlanetController.PullShip(gravVelocity, shipTransform);
    }
}
