using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] float despawnInterval = 1f;

    public RectTransform canvasRect;

    public int cantidadInstanciasMaximas = 99;
    private int botonesPulsados = 0;

    static bool inGame = true;

    [SerializeField] float bossAnimationTime = 8f;

    [SerializeField] GameObject winCanva;

    private void Start()
    {
        StartCoroutine(SpawnButtonCoroutine());
    }

    IEnumerator SpawnButtonCoroutine()
    {
        while (inGame)
        {
            SpawnButton();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnButton()
    {
        if (cantidadInstanciasMaximas > 0 && inGame == true)
        {
            float x = Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f);
            float y = Random.Range(-canvasRect.rect.height / 2f, canvasRect.rect.height / 2f);

            Vector2 posicionAleatoria = new Vector2(x, y);

            GameObject button = Instantiate(buttonPrefab, canvasRect.TransformPoint(posicionAleatoria), Quaternion.identity, canvasRect);
            RectTransform buttonRect = button.GetComponent<RectTransform>();

            if (buttonRect != null)
            {
                buttonRect.anchoredPosition = posicionAleatoria;
            }

            Button boton = button.GetComponent<Button>();
            if (boton != null)
            {
                boton.onClick.AddListener(ContarBotonPulsado);
            }

            StartCoroutine(DespawnButton(button));
        }
    }

    IEnumerator DespawnButton(GameObject button)
    {
        yield return new WaitForSeconds(despawnInterval);
        if (button != null)
        {
            Destroy(button);
            cantidadInstanciasMaximas--;
        }
    }

    public void ContarBotonPulsado()
    {
        botonesPulsados++;
        if(botonesPulsados == 15)
        {
            BossFinal.instance.StartAnimationBoss();
            StopSpawn();

            StartCoroutine(FinalGame());
        }
    }

    IEnumerator FinalGame() 
    {
        yield return new WaitForSeconds(bossAnimationTime);
        winCanva.SetActive(true);
    }

    public void StartSpawn()
    {
        inGame = true;
    }

    public void StopSpawn()
    {
        inGame = false;
    }
}
