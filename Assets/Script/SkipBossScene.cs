using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReloadOnPress5 : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            NavigationManager.LoadScene("BossFinalScene");
        }
    }

}

