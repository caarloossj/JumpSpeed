using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    static public bool isDay;

    [SerializeField] bool startingIsDay = true;

    bool wasDay = false;

    public GameObject nightLight;
    public GameObject dayLight;
    public GameObject playerLight;

    public GameObject snakeSpawn;

    private void Start()
    {
        wasDay = isDay = startingIsDay;

        dayLight.SetActive(true);
    }

    private void Update()
    {
        if (!wasDay && isDay)
        {
            NightPlatform[] nightPlatforms = GameObject.FindObjectsOfType<NightPlatform>();

            foreach (NightPlatform np in nightPlatforms)
            { 
                np.SetDay(); 
            }
            nightLight.SetActive(true);
            dayLight.SetActive(false);
            playerLight.SetActive(true);
            snakeSpawn.GetComponent<SnakeSpawner>().StartSpawn();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            NightPlatform[] nightPlatforms = GameObject.FindObjectsOfType<NightPlatform>();

            foreach (NightPlatform np in nightPlatforms)
            { 
                np.SetNight(); 
            }

            isDay = false;
            dayLight.SetActive(false);
            nightLight.SetActive(true);
            playerLight.SetActive(true);
            snakeSpawn.GetComponent<SnakeSpawner>().StartSpawn();
        }

        wasDay = isDay;
    }

    public GameObject GetSnakeSpawner()
    {
        return snakeSpawn;
    }
}
