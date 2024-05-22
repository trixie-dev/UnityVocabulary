using System.Collections.Generic;
using UnityEngine;


public class Tab : MonoBehaviour
{
    public GameObject MainTabObject;
    protected List<GameObject> tabsObjects = new List<GameObject>();
    
    public void ShowAll()
    {
        foreach (var viewObject in tabsObjects)
        {
            viewObject.SetActive(true);
        }
        
        MainTabObject.SetActive(true);
    }
    
    public void HideAll()
    {
        MainTabObject.SetActive(false);
        
        foreach (var viewObject in tabsObjects)
        {
            viewObject.SetActive(false);
        }
    }
}
