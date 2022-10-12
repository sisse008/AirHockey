using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuController : MonoBehaviour
{
   
    public Animator menu_animations;


    private void HideMenu()
    {
        menu_animations.SetBool("open", false);
    }

    private void ShowMenu()
    {
        menu_animations.SetBool("open", true);
    }

    public void ToggleMenu()
    {
        bool isOpen = menu_animations.GetBool("open");
        if (isOpen)
            HideMenu();
        else
            ShowMenu();
    }
}
