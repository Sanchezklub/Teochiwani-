using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    public void ToggleFullscreen()
    {
        Screen.fullScreen = true;
    } 

    public void ToggleWindowed()
    {
        Screen.fullScreen = false;
    }


}

