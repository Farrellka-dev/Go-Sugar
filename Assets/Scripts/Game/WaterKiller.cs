using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKiller : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private int hitpoint = 3;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
            col.transform.position = spawnPoint.position;
        hitpoint--;
        if (hitpoint <= 0)
        {
            Debug.Log("Game Over");
        }
    }
   
}
