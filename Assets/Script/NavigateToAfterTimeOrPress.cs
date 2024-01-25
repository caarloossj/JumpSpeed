using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] string sceneToNavigateTo;
    [SerializeField] float waitTime = 2f;
    [SerializeField] InputActionReference skip;

    private void Start()
    {
        Invoke(nameof(NavigateToNextScene), waitTime);
    }

    void NavigateToNextScene()
    {
        NavigationManager.LoadScene(sceneToNavigateTo);
    }
}
