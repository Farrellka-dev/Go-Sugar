using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private int hitpoint = 3;

    public Vector3 spawnPosition;
    public Transform playerTransform;
    void Update()
    {
        if (playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPosition;
            hitpoint--;
            if (hitpoint <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
