using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Rune : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInChildren<AudioSource>().Play();
            RuneManager.instance.NotificarRunaCogida();
            gameObject.SetActive(false);
        }
    }
}
