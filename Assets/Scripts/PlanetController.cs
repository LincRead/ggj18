using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetController : MonoBehaviour {

    const int MIN_MASS = 20;
    const int MAX_MASS = 50;
    const int MIN_RADIUS = 1;
    const int MAX_RADIUS = 5;

    public float mapLength;
    public float planetSpacing;

    public GameObject[] planetPrefabs;

    Dictionary<GameObject, Planet> planets;
    Transform shipTransform;
    public static PlanetController current;
    // Use this for initialization
    void Start () {
        planets = new Dictionary<GameObject, Planet>();
        //planets.Add(new GameObject("planet"), new Planet(new Vector3(5, 10, 0), 5, 10));
        CreatePlanets();
        shipTransform = WorldManager.instance.ship.transform;
        current = this;
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Planet planet in planets.Values)
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
        for(float i = planetSpacing; i < mapLength; i += planetSpacing)
        {
            CreatePlanet(i);
        }
    }

    void CreatePlanet(float xIndex)
    {
        Planet planet = new Planet(new Vector3(xIndex, UnityEngine.Random.Range(0, 10), 0),
                                UnityEngine.Random.Range(MIN_MASS, MAX_MASS),
                                UnityEngine.Random.Range(MIN_RADIUS, MAX_RADIUS));
        GameObject planetGO = Instantiate(planetPrefabs[(int)planet.radius - 1], planet.location, Quaternion.identity, this.transform);
        planets.Add(planetGO, planet );
    }

    public bool IsWinPlanet(GameObject go_planet)
    {
        return planets[go_planet].isGoalPlanet;
    }

}
