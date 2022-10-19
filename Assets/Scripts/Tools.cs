using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tools
{
    private static readonly System.Random getrandom = new System.Random();
    public static int GetRandomNumber(int min, int max)
    {
        lock (getrandom) // synchronize
        {
            return getrandom.Next(min, max);
        }
    }
    public static T GetComponent<T>(GameObject go) where T : MonoBehaviour
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }
}
