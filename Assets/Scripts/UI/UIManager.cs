using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CanvasScaler canvasScalar;
    private void OnEnable()
    {
        if (!Tools.IsMobile())
        {
            enabled = false;
        }
        canvasScalar.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScalar.matchWidthOrHeight = 0.38f;
        //TODO: if portrair -> OnPortrait() else -> OnLandscape()
    }


    void OnLandscape()
    { 
    }

    void OnPortrait()
    { 
    }

 
}
