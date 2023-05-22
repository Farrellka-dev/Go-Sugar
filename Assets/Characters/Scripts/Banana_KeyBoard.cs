using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana_KeyBoard : MonoBehaviour
{
    public BananaScript Banana;

    private void Start()
    {

        Banana = Banana == null ? GetComponent<BananaScript>() : Banana;
        if (Banana == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {

        if (Banana != null)
        {

            if (Input.GetKey(KeyCode.D))
            {
                Banana.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Banana.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Banana.Jump();
            }
        }
    }
}
