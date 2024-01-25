using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class RuneManager : MonoBehaviour
{
    public TMP_Text contadorText;
    public static RuneManager instance;
    private int runaCount = 0;

    public void NotificarRunaCogida()
    {
        runaCount++;
        contadorText.text = "" + runaCount.ToString();

        if (runaCount == 5)
        { 
            NavigationManager.LoadScene("BossFinalScene");   
        }
    }

    public void Awake()
    {
        instance = this;
    }

}