using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    public MenuManager menuManager;
    public SessionManager sessionManager;
    private List<Tab> _tabs = new List<Tab>();

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        _tabs.Add(menuManager);
        _tabs.Add(sessionManager);
        Storage.Initialize();
        menuManager.Initialize();
        
        MainMenu();
    }

    public void MainMenu()
    {
        ChangeTab(menuManager);
        menuManager.LoadMainMenu();
    }

    public void StartSession(TopicModel topic, bool isReverse)
    {
        ChangeTab(sessionManager);
        sessionManager.StartSession(topic, isReverse);
    }
    
    private void ChangeTab(Tab tab)
    {
        foreach (var t in _tabs)
        {
            t.HideAll();
        }
        tab.ShowAll();
    }
}
