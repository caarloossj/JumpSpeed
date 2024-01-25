using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager instance;

    [SerializeField] string firstSceneToLoad; 
    CanvasGroup canvasGroup;
    Scene lastLoadedScene;

    private void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();   
    }

    private void Start()
    {
        instance = this;
        LoadScene(firstSceneToLoad);
    }

    public static void LoadScene(string sceneName)
    {
        instance.LoadSceneInternal(sceneName);
    }

    public void LoadSceneInternal(string sceneName)
    {
        if(!sceneName.Equals(""))
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }   
    }

    IEnumerator LoadSceneCoroutine(string sceneName) 
    {
        if (lastLoadedScene.isLoaded) 
        {
            Tween fadeOut = canvasGroup.DOFade(1f, 2f).SetAutoKill(false);
            while(!fadeOut.IsComplete())
            {
                yield return null;
            }
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(lastLoadedScene);
            while(!unloadOperation.isDone) 
            {
                yield return null;
            }
        }

        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loadOperation.isDone)
            {
                yield return null;
            }

            lastLoadedScene = SceneManager.GetSceneByName(sceneName);

            Tween fadeIn = canvasGroup.DOFade(0f, 2f).SetAutoKill(false);
            while (!fadeIn.IsComplete())
            {
                yield return null;
            }
        }
    }
}
