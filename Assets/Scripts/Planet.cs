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
        if (IsSpaceshipInGravWell(shipTransform.position))
            PullShip(shipTransform.position);
    }

    public bool IsSpaceshipInGravWell(Vector3 spaceshipPos) {
        if (Vector3.Distance(spaceshipPos, location) < gravWellRadius)
            return true;
        return false;
    }

    void PullShip(Vector3 shipTransform)
    {
        Vector2 gravVelocity = new Vector2(Mathf.Abs(location.x - shipTransform.x) - (mass * radius), Mathf.Abs(location.y - shipTransform.y) - (mass * radius));
        PlanetController.PullShip(gravVelocity, shipTransform);
    }
}
