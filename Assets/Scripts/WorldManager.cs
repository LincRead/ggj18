using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private static WorldManager worldManager;

    [HideInInspector]
    public GameObject ship;

    public bool enteredFinishPlanet = false;
    public bool won = false;
    public bool gameover = false;

    public static WorldManager instance
    {
        get
        {
            if (!worldManager)
            {
                worldManager = FindObjectOfType(typeof(WorldManager)) as WorldManager;

                if (!worldManager)
                {
                    Debug.LogError("There needs to be one active WorldManager script on a GameObject in your scene.");
                }

                else
                {
                    worldManager.Init();
                }
            }

            return worldManager;
        }
    }

    void Init()
    {
        
    }

    void OnEnable()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    public void RestartGame()
    {

    }
}