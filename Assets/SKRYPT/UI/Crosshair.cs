using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]  RectTransform rectTransform;
    void Update()
    {
        rectTransform.position = Input.mousePosition;
    }
}
