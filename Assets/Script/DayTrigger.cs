using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTrigger : MonoBehaviour
{
    DayNightManager dayNightManager;

    public void Start()
    {
        dayNightManager = GameObject.FindWithTag("DayNightManager").GetComponent<DayNightManager>(); 
    }
    public void OnTriggerEnter(Collider grass)
    {
        if (grass.gameObject.CompareTag("Player"))
        {
            DayNightManager.isDay = true;

            GameObject nightLIGHT = FindObjectOfType<DayNightManager>().nightLight;
            GameObject dayLIGHT = FindObjectOfType<DayNightManager>().dayLight;
            GameObject playerLIGHT = FindAnyObjectByType<DayNightManager>().playerLight;
            nightLIGHT.SetActive(false);
            dayLIGHT.SetActive(true);
            playerLIGHT.SetActive(false);

            dayNightManager.GetSnakeSpawner().GetComponent<SnakeSpawner>().StopSpawn();
        }
    }
}