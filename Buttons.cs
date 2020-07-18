using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject StuffMenu;
    private bool isStuffMenuOpen = false;
    public void StuffButton() 
    {
        if (!isStuffMenuOpen) { StuffMenu.SetActiveRecursively(true); isStuffMenuOpen = true; Debug.Log("open"); }
        else { StuffMenu.SetActiveRecursively(false); isStuffMenuOpen = false; Debug.Log("close"); }
    }

    public void SettingsButton() 
    {
        SceneManager.LoadScene("Settings"); 
    }

    public void ShopButton() 
    {
        ShopMenu.SetActiveRecursively(true);
    }

    public void ShopButtonClose() 
    {
        ShopMenu.SetActiveRecursively(false);
    }

}
