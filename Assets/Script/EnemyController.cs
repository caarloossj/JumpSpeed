using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Player.instance.ActiveCanva();
        }
    }
}
