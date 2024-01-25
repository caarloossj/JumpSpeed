using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private const float playerSpawnDistance = 7f;
    [SerializeField] private Transform platformStart;
    [SerializeField] private List<Transform>platformEasyList;
    [SerializeField] private Player player;

    private Vector3 endPositionBefore;

    public GameObject parentPlatform;

    private void Awake()
    {
        endPositionBefore = platformStart.Find("EndPosition").position;
    }

    private void Update()
    {
        //Recoge la posición del player y si la posición es mas corta que playerSpawnDistance aparecen las nuevas plataformas.
        if(Vector3.Distance(player.transform.position, endPositionBefore) < playerSpawnDistance)
        {
            SpawnerPlatformPart();
        }
    }

    //Aqui obtenemos la lista de prefabs de las plataformas y con un random haremos spawnear la siguiente plataforma.
    private void SpawnerPlatformPart()
    {
        Transform levelPart = platformEasyList[Random.Range(0, platformEasyList.Count)];
        Transform lastPlatformTransform = SpawnerPlatformPart(levelPart , endPositionBefore);
        endPositionBefore = lastPlatformTransform.Find("EndPosition").position;
    }

    private Transform SpawnerPlatformPart(Transform platformEasyList ,Vector3 spawnPosition)
    {
        Transform platformTransform = Instantiate(platformEasyList, spawnPosition, Quaternion.identity);
        platformTransform.transform.parent = parentPlatform.transform;
        return platformTransform;
    }

    public void DeleteAllPlatforms()
    {
        Destroy(parentPlatform.gameObject);
    }
}
