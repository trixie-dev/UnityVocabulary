using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    public LoginManager loginManager;
    public MenuManager menuManager;
    public SessionManager sessionManager;
    public LoadingManager loadingManager;

    public FirebaseManager FirebaseManager;
    private List<Tab> _tabs = new List<Tab>();

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        _tabs.Add(loginManager);
        _tabs.Add(menuManager);
        _tabs.Add(sessionManager);
        _tabs.Add(loadingManager);
        ChangeTab(menuManager);
        menuManager.Initialize();
        ChangeTab(loadingManager);
        Storage.Initialize();
        FirebaseManager = new FirebaseManager();
        FirebaseManager.Initialize();
        //InvokeRepeating(nameof(CheckFirebaseLogin), 1, 1);
        Invoke(nameof(CheckFirebaseLogin) ,1);
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FirebaseManager.AuthManager.SignOut();
        }
    }

    private void CheckFirebaseLogin()
    {
        bool isLoggedIn = FirebaseManager.AuthManager.CheckIfUserIsLoggedIn();
        if (isLoggedIn)
        {
            MainMenu();
        }
        else
        {
            ChangeTab(loginManager);
        }
    }
    public void MainMenu()
    {
        ChangeTab(menuManager);
        menuManager.LoadVocabularyMenu();
    }

    public void StartSession(TopicModel topic, bool fromEnglish)
    {
        ChangeTab(sessionManager);
        sessionManager.StartSession(topic, fromEnglish);
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
