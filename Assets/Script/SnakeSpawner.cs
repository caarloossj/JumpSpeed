using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] GameObject snakePrefab;
    [SerializeField] float spawnInterva = 1f;
    [SerializeField] float despawnInterval = 3f;

    static public bool inGame = false;

    DayNightManager dayNightManager;
    Coroutine spawnCoroutine;

    void Start()
    {
        dayNightManager = GameObject.FindWithTag("DayNightManager").GetComponent<DayNightManager>();
    }

    IEnumerator SpawnSnakeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterva);

            if (inGame)
            {
                SpawnSnakes();
            }
        }
    }

    public void SpawnSnakes()
    {
        Vector3 posicionObjetoActual = transform.position;
        GameObject snake = Instantiate(snakePrefab, posicionObjetoActual, Quaternion.identity);
        StartCoroutine(DespawnSnake(snake));
    }

    IEnumerator DespawnSnake(GameObject snake)
    {
        yield return new WaitForSeconds(despawnInterval);
        if (snake != null)
        {
            Destroy(snake);
        }
    }
    public void StartSpawn()
    {
        inGame = true;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine(SpawnSnakeCoroutine());
    }

    public void StopSpawn()
    {
        inGame = false;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
