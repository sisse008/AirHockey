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
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            HighlightDynamic();
            ShowArea();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            UnHighlight();
            ShowArea(true);
        }
    }

    void ShowArea(bool hide = false)
    {
        Color c = _material.color;
        c.a = hide? 0f : 0.3f;
        _material.color = c;
    }
}
