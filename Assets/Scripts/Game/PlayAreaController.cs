using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaController : Highlightable
{
    Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }
    public void PropmptWarning(bool prompt = true)
    {
        if (prompt)
        {
            HighlightDynamic();
        }
        else { UnHighlight(); }
        ShowArea(!prompt);
    }

    void ShowArea(bool hide = false)
    {
        Color c = _material.color;
        c.a = hide? 0f : 0.3f;
        _material.color = c;
    }
}
