using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    
    
    
   

    public void SendName()
    {
        GameObject menu = GameObject.Find("MenuManager");

        DB db = menu.GetComponent<DB>();
        MenuScript menuScript = menu.GetComponent<MenuScript>(); 
        Button button = GetComponent<Button>();
        db.choices.Add(Int32.Parse(button.name));
        menuScript.isSelected = true;
        menuScript.choise = Int32.Parse(button.name);

    }
}
