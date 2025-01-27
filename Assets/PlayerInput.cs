using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool JumpUp;
    public bool JumpDown;
    public int MoveAxis = 0;

    private void Start()
    {
        Input.simulateMouseWithTouches = false;
    }
    void Update()
    {
        JumpUp = false;
        JumpDown = false;
        MoveAxis = 0;

        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            JumpDown = true;
        }

        if (Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetMouseButtonUp(0))
        {
            JumpUp = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("JoystickAxis") > 0.5)
        {
            MoveAxis = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("JoystickAxis") < -0.5)
        {
            MoveAxis = -1;
        }

    }
}
