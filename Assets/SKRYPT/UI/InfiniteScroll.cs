using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Image img;
    private void Update()
    {
        Vector2 Offset = new Vector2(speed * Time.unscaledTime, 0);
        img.material.mainTextureOffset = Offset;
    }
}
