using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimations : MonoBehaviour
{
    public Color selectedColor;
    public float duration;
    public float enlargeScaleFactor;


    Button button;
    RectTransform rt;

    private void Awake()
    {
        button = GetComponent<Button>();
        rt = button.GetComponent<RectTransform>();
    }
    protected void EnlargeButton()
    {
        StartCoroutine(EnlargeButton(duration)); ;
    }

    IEnumerator EnlargeButton(float duration)
    {
        float time = 0;
        Vector2 currentsize = rt.sizeDelta;
        Vector2 targetSize = currentsize + currentsize * enlargeScaleFactor;
        while (time < duration)
        {
            time += Time.deltaTime;
            rt.sizeDelta = Vector3.Lerp(currentsize, targetSize, time / duration);
            yield return null;
        }
    }

    protected void ChangeColor()
    {
        StartCoroutine(ChangeColor(duration));
    }

    IEnumerator ChangeColor(float duration)
    {
        float currentFade = 0;
        Material m = button.gameObject.GetComponent<MeshRenderer>().material;
        Color currentColor = m.color;
        while (currentFade < duration)
        {
            currentFade += Time.deltaTime;
            m.color = Color.Lerp(currentColor, selectedColor, currentFade / duration);
            yield return null;
        }
    }
}
