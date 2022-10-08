using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public virtual void StartNewGame()
    {
    }
    
    public virtual void QuitGame()
    {
        Application.Quit();
    }
}
