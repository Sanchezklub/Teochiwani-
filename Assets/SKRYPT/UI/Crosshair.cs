using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] CharacterController2D player;
    [SerializeField] private Image img;
    private Vector3 OldPos;
    void Update()
    {
        rectTransform.position = Input.mousePosition;
        if (img.color.a == 1)
        {
            ManagePlayer();
        }
        OldPos = rectTransform.position;
    }

    void ManagePlayer()
    {
        if (rectTransform.position != OldPos)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (MousePos.x > player.transform.position.x && !player.isFacingRight)
            {
                Debug.Log("Crosshair called flip");
                player.Flip();
            }
            else if (MousePos.x < player.transform.position.x && player.isFacingRight)
            {
                Debug.Log("Crosshair called flip");
                player.Flip();
            }

        }
    }
}
