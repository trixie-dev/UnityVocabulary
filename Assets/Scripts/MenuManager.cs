using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : Tab
{
    public GameObject MenuItemPrefab;
    
    public Transform MenuContainer;
    
    
    private List<MenuItem> _menuItems = new List<MenuItem>();
    
    
    public void Initialize()
    {
        LoadMainMenu();
    }


    public void LoadMainMenu()
    {
        ClearMenu();
        MenuItem item = new MenuItem("1 - Vocabulary", LoadVocabularyMenu);
        _menuItems.Add(item);
        RenderMenu();
    }
    
    public void LoadVocabularyMenu()
    {
        ClearMenu();
        for(int i = 0; i < Storage.VocabularyTopics.Length; i++)
        {
            int index = i;
            MenuItem item = new MenuItem($"Topic {i + 1}", () =>
            {
                GameManager.Instance.StartSession(index, false);
            });
            _menuItems.Add(item);
        }
        RenderMenu();
    }

    private void RenderMenu()
    {
        foreach (var menuItem in _menuItems)
        {
            GameObject menuItemInstance = Instantiate(MenuItemPrefab, MenuContainer);
            menuItemInstance.GetComponentInChildren<TextMeshProUGUI>().text = menuItem.Name;
            Button btn = menuItemInstance.GetComponent<Button>();
            btn.onClick.AddListener(() => { menuItem.Action(); });
            menuItem.SetInstance(menuItemInstance);
        }
    }
    
    private void ClearMenu()
    {
        // clear menu items
        foreach (var menuItem in _menuItems)
        {
            Destroy(menuItem.Instance);
        }
        _menuItems.Clear();
    }
    
}


public class MenuItem
{
    public string Name { get; set; }
    public Action Action { get; set; }
    public GameObject Instance { get; set; }
    
    public MenuItem(string name, Action action)
    {
        Name = name;
        Action = action;
    }
    
    public void SetInstance(GameObject instance)
    {
        Instance = instance;
    }
}