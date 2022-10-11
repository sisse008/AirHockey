using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
public class Highlightable : MonoBehaviour, IHighlightable
{
    Outline outline;
    private void Start()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineColor = new Color(0,255,0,255);
        outline.OutlineWidth = 8;
    }

    public void Highlight()
    {
        outline.ActivateOutline();
    }


    public void UnHighlight()
    {
        outline.DeactivateOutline();
    }
}
