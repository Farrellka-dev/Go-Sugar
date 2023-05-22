using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
            LevelConroller.instace.isEndGame();
            Debug.Log("YRA");     
    }

}