using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sugar : MonoBehaviour
{
    public int Sugarnost;
    void OnTriggerEnter2D(Collider2D col)
    {
        Sugar_Player.Sugar += Sugarnost;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Sugar_Player>().TextSugar.text = Sugar_Player.Sugar.ToString();
        Destroy(gameObject);
    }
}
