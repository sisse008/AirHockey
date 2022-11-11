using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Outline))]
public class Highlightable : MonoBehaviour, IHighlightable
{
    public Outline outline;
    bool highlighted;
    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = new Color(0,255,0,255);
        outline.OutlineWidth = 8;
        highlighted = false;
    }

    public void Highlight()
    {
        outline.ActivateOutline();
        highlighted = true;
    }


    public void UnHighlight()
    {
        if (outline == null)
            Debug.Log("NO OUTLINEEE. NAME = " + name);
        if (highlighted == false)
            return;
        outline.DeactivateOutline();
        highlighted = false;
    }

    public void HighlightDynamic()
    {
        Highlight();
        StartCoroutine(AnimateOutlineWidth());
    }

    IEnumerator AnimateOutlineWidth()
    {
        while (highlighted)
        {
            yield return ChangeOutlineWidth(1, 0);
            yield return ChangeOutlineWidth(1, 30);
        }
    }

    IEnumerator ChangeOutlineWidth(float duration, float targetWidth)
    {
        float timer = 0;
        float currentWidth = outline.OutlineWidth;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            outline.OutlineWidth = Mathf.Lerp(currentWidth, targetWidth, timer / duration);
            yield return null;
        }
    }
}
