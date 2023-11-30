using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ControlButton : MonoBehaviour
{
    public enum ButtonType { MoveLeft, MoveRight, Jump }
    public PlayerInput pi;
    public GraphicRaycaster gr;
    public ButtonType Button = ButtonType.Jump;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = touch.position;
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pointer, results);
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject == gameObject)
                    {
                        if (result.gameObject == gameObject)
                        {
                            if (Button == ButtonType.MoveLeft)
                            {
                                pi.MoveAxis = -1;
                            }
                            else if (Button == ButtonType.MoveRight)
                            {
                                pi.MoveAxis = 1;
                            }
                            else if (Button == ButtonType.Jump)
                            {
                                if (touch.phase == TouchPhase.Began)
                                {
                                    pi.JumpDown = true;
                                }
                                else if (touch.phase == TouchPhase.Ended)
                                {
                                    pi.JumpUp = true;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
