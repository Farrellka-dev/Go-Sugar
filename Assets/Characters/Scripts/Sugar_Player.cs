using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sugar_Player : MonoBehaviour
{
    static public int Sugar;
    [SerializeField]
    public Text TextSugar;


    void Start()
    {
        Sugar=0;
    }
}
