using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetController : MonoBehaviour {

    const int MIN_PLANETS = 4;
    const int MAX_PLANETS = 10;
    const int MIN_MASS = 4;
    const int MAX_MASS = 10;
    const int MIN_RADIUS = 2;
    const int MAX_RADIUS = 5;
    List<Planet> planets;
    Transform shipTransform;
    public static PlanetController current;
    // Use this for initialization
    void Start () {
        planets = new List<Planet>();
        planets.Add(new Planet(new Vector3(5, 10, 0), 5, 10));
        //CreatePlanets();
        shipTransform = GameObject.FindGameObjectWithTag("Player").transform;
        current = this;
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Planet planet in planets)
        {
            planet.Update(shipTransform);
        }
	}

    public static void PullShip(Vector2 pullVector, Vector3 shipTransformPos)
    {
        PlanetController.current.shipTransform.position += new Vector3(pullVector.x * Time.deltaTime, pullVector.y * Time.deltaTime, 0);
    }

    void CreatePlanets()
    {
        for(int i = 0; i < UnityEngine.Random.Range(MIN_PLANETS, MAX_PLANETS); i++)
        {
            CreatePlanet();
        }
    }

    void CreatePlanet()
    {
        planets.Add(new Planet(new Vector3(UnityEngine.Random.Range(100, 200), UnityEngine.Random.Range(100, 200), 0),
                                UnityEngine.Random.Range(MIN_MASS, MAX_MASS),
                                UnityEngine.Random.Range(MIN_RADIUS, MAX_RADIUS)));
    }
}
