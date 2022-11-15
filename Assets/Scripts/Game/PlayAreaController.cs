using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boundry
{
    Vector2 xRange;
    // Vector2 yRange;
    Vector2 zRange;

    public Boundry(Vector2 xRange, Vector2 zRange)
    {
        this.xRange = xRange;
        // this.yRange = yRange;
        this.zRange = zRange;
    }
    public float MinX => xRange.x;
    public float MaxX => xRange.y;

    // public float MinY => yRange.x;
    //  public float MaxY => yRange.y;

    public float MinZ => zRange.x;
    public float MaxZ => zRange.y;
}
public class PlayAreaController : Highlightable
{
    Material _material;
    public Boundry boundries = null;

    protected override void Awake()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
        var bounds = GetComponent<MeshRenderer>().bounds;
        // Debug.Log(bounds);
        boundries = new Boundry(new Vector2(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x),
            new Vector2(bounds.center.z - bounds.extents.z, bounds.center.z + bounds.extents.z));
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
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
