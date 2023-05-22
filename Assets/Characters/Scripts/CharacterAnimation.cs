using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    private Animator anima;
    SpriteRenderer sprite;

    void Start()
    {
        anima.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anima.Play("BananaRun");
        }
        else
            if(Input.GetKey(KeyCode.D))
            {
            anima.Play("BananaRun");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anima.Play("BananaJump");
        }
        else 
        {
            anima.Play("BananaIdle");
        }
    }

        private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anima.SetBool("isRunning", true);
        }
        else
        {
            anima.SetBool("isRunning", false);
        }
    }

}