using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {

    Vector2 location;
    float mass;
    float radius;
    float gravWellRadius;

    public Planet(Vector2 location, float mass, float radius, float gravWellRadius) {
        this.location = location;
        this.mass = mass;
        this.radius = radius;
        this.gravWellRadius = gravWellRadius;
    }

    public void Update() {
        if (IsSpaceshipInGravWell(GameObject.FindGameObjectWithTag("Player").transform.position))
            PullShip();
    }

    public bool IsSpaceshipInGravWell(Vector2 spaceshipPos) {
        if (Vector2.Distance(spaceshipPos, location) < gravWellRadius)
            return true;
        return false;
    }

    void PullShip()
    {
        Vector2 gravVelocity = new Vector2(location.x + (mass * radius), location.y + (mass * radius));
        WorldManager.PullShip(gravVelocity);
    }
}
