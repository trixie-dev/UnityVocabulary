using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : Tab
{
    public GameObject MenuItemPrefab;
    public Transform MenuContainer;
    public Toggle ModeToggle;
    
    private bool _isEnglishMode => ModeToggle.isOn;
    
    
    private List<MenuItem> _menuItems = new List<MenuItem>();
    
    
    public void Initialize()
    {
        ModeToggle.onValueChanged.AddListener((value) =>
        {
            LoadVocabularyMenu();
        });
    }


    public void LoadMainMenu()
    {
        ClearMenu();
        //MenuItem item = new MenuItem("1 - Vocabulary", LoadVocabularyMenu);
        //_menuItems.Add(item);
        RenderMenu();
    }
    
    public void LoadVocabularyMenu()
    {
        ClearMenu();
        for(int i = 0; i < Storage.VocabularyTopics.Length; i++)
        {
            MenuItem item;
            TopicModel topic = Storage.VocabularyTopics[i];
            bool isCompleted = _isEnglishMode ? topic.IsCompletedFromEnglish : topic.IsCompletedFromNative;
            int accuracy = _isEnglishMode ? topic.EnglishAccuracy : topic.NativeAccuracy;
            List<QuestionModel> questions = new List<QuestionModel>(Storage.GetVocabularyWords(topic.Index));
            string spoiler = "";
            for(int j = 0; j < 5 && j < questions.Count; j++)
            {
                spoiler += $"{questions[j].GetWorld(_isEnglishMode)}, ";
                
            }
            item = new MenuItem($"{i + 1}", spoiler,  accuracy, isCompleted, () =>
            {
                GameManager.Instance.StartSession(topic, _isEnglishMode);
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
            menuItem.SetMenuObject(menuItemInstance.GetComponent<MenuItemObject>());
        }
    }
    
    private void ClearMenu()
    {
        // clear menu items
        foreach (var menuItem in _menuItems)
        {
            Destroy(menuItem.MenuObject.gameObject);
        }
        _menuItems.Clear();
    }
    
}


public class MenuItem
{
    private string Title;
    private string SpoilerText;
    private int Stat;
    private bool IsCompleted;
    public Action Action { get; set; }
    public MenuItemObject MenuObject { get; set; }
    
    public MenuItem(string title, string spoilerText, int stat, bool isCompleted, Action action)
    {
        Title = title;
        SpoilerText = spoilerText;
        Stat = stat;
        IsCompleted = isCompleted;
        Action = action;
    }

    private void Init()
    {
        Color gray = new Color(0.5f, 0.5f, 0.5f);
        MenuObject.Title.color = IsCompleted ? Color.green : gray;
        MenuObject.Title.text = Title;
        MenuObject.SpoilerText.color = IsCompleted ? Color.green : gray;
        MenuObject.SpoilerText.text = SpoilerText;
        MenuObject.StatText.color = IsCompleted ? Color.green : gray;
        MenuObject.StatText.text = $"Accuracy: {Stat}%";
        MenuObject.Border.color = IsCompleted ? Color.green : new Color(0.5f, 0.5f, 0.5f);
        MenuObject.Button.onClick.AddListener(() => { Action(); });
    }
    
    public void SetMenuObject(MenuItemObject menuObject)
    {
        MenuObject = menuObject;
        Init();
    }
}