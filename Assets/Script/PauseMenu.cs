using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionReference pause;
    [SerializeField] GameObject pauseMenu;

    private void OnEnable()
    {
        pause.action.Enable();
        pause.action.performed += OpenMenu;
    }

    private void OnDisable()
    {
        pause.action.Disable();
        pause.action.performed -= OpenMenu;
    }

    public void OpenMenu(InputAction.CallbackContext context)
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
