using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {

    Slider slider;
    ShipCotroller ship;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        ship = WorldManager.instance.ship.GetComponent<ShipCotroller>();

    }
	
	// Update is called once per frame
	void Update () {
        slider.value = ship.shieldPowerCurrent / ship.shieldPower;

    }
}
