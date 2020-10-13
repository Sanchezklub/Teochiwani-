using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlider : MonoBehaviour
{
    [Range(0f, 1f)]
    public float targetValue;
    public float speed;

    public Image foregroundFill;
    public RectTransform head;

    [Header("HeadMovement")]
    public float minX;
    public float maxX;

    void Update()
    {
        foregroundFill.fillAmount = Mathf.Lerp(foregroundFill.fillAmount, targetValue, Time.unscaledDeltaTime * speed);

        if (head == null)
            return;

        var pos = head.anchoredPosition;
        var target = Mathf.Lerp(minX, maxX, targetValue);
        pos.x = Mathf.Lerp(pos.x, target, Time.unscaledDeltaTime * speed);
        head.anchoredPosition = pos;
    }
}
