using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuController : MonoBehaviour
{
   
    public Animation menu_animations;

    public void HideMenu()
    {
        menu_animations.Play("close");
    }

    public void ShowMenu()
    {
        menu_animations.Play("open");
    }
}
