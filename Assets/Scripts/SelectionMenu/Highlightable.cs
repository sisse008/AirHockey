using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
public class Highlightable : MonoBehaviour, IHighlightable
{
    bool highlighted;
    MeshRenderer[] meshRenderer;

    private Material outlineMaskMaterial;
    private Material outlineFillMaterial;

    protected virtual void Start()
    {
       // outline.OutlineColor = new Color(0,255,0,255);
      //  outline.OutlineWidth = 8;
        highlighted = false;
    }

    protected virtual void Awake()
    {
        meshRenderer = GetComponentsInChildren<MeshRenderer>();
        outlineMaskMaterial = Instantiate(Resources.Load<Material>(@"Materials/OutlineMask"));
        outlineFillMaterial = Instantiate(Resources.Load<Material>(@"Materials/OutlineFill"));
    }

    protected virtual void OnEnable()
    {
        foreach (var renderer in meshRenderer)
        {
            // Append outline shaders
            var materials = renderer.sharedMaterials.ToList();

            materials.Add(outlineMaskMaterial);
            materials.Add(outlineFillMaterial);

            renderer.materials = materials.ToArray();
        }
    }

    public void Highlight()
    {
      //  outline.ActivateOutline();
        highlighted = true;
    }


    public void UnHighlight()
    {
       /* if (outline == null)
            Debug.Log("NO OUTLINEEE. NAME = " + name);
        if (highlighted == false)
            return;
        outline.DeactivateOutline();
        highlighted = false;
       */
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


    //TODO: use this to activate and disable highlight
    IEnumerator ChangeOutlineWidth(float duration, float targetWidth)
    {
        float timer = 0;
       // float currentWidth = outline.OutlineWidth;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            //outline.OutlineWidth = Mathf.Lerp(currentWidth, targetWidth, timer / duration);
            yield return null;
        }
    }
}
