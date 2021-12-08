using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;

    public void Update()
    {
        // check input
        if (Input.GetKey(KeyCode.W))
        {
            // move up
            Corgi.Move(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            Corgi.Move(2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move down
            Corgi.Move(3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            Corgi.Move(4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // shoot beer
        }
        else
        {
            // no input
            Corgi.Move(0);
        }
    }
}
