using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
public class Highlightable : MonoBehaviour, IHighlightable
{
    public Outline outline;
    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = new Color(0,255,0,255);
        outline.OutlineWidth = 8;
    }

    public void Highlight()
    {
        outline.ActivateOutline();
    }


    public void UnHighlight()
    {
        if (outline == null)
            Debug.Log("NO OUTLINEEE. NAME = " + name);
        outline.DeactivateOutline();
    }
}
