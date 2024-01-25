using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject cameraFollow;

    private void Update()
    {
        transform.position = cameraFollow.transform.position;
    }
}
