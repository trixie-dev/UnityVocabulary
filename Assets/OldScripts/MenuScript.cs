using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    
    public GameObject buttonPrefab;
    public GameObject canvas;
    public GameObject toggleSwitch;
    public DB db;

    public bool isSelected = false;
    public bool nextMenu = false;
    public int choise = 0;
    public int numberOfWords = 100; 

    bool isSpawned = false;
    bool isTestActive = false;
    bool isDone = false;
    
    float screenWidth;
    float screenHeight;


    

    void Start()
    {


        toggleSwitch = GameObject.Find("ToggleSwitch");
        toggleSwitch.SetActive(false);
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        string[] mainMenu = { "Main Menu"};
        Dictionary<string, bool> blocksDict = new Dictionary<string, bool>();
        foreach (string str in mainMenu)
        {
            blocksDict[str] = false;
        }
        LoadMenu(blocksDict);


    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (isSelected == true)
        {
            
            ClearList();
            isDone = false;
            isSpawned = false;
            isSelected = false;
        }
        if (db.choices.Count == 1 && !isDone)
        {
            //GameObject.Find("ReportInfo").SetActive(false);
            GameObject.Find("ClearProgress").SetActive(false);
            if (db.choices[0] == 0 && !isSpawned)
            {
                string[] list = { "11", "22", "33", "44", "55", "66", "77" };
                Dictionary<string, bool> blocksDict = new Dictionary<string, bool>();
                foreach (string str in list)
                {
                    blocksDict[str] = false;
                }
                LoadMenu(blocksDict);
                isSpawned = true;
                isDone = true;
                toggleSwitch.SetActive(true);
            }
            

        }
        if (db.choices.Count == 2 && !isDone)
        {
            
            if (db.choices[0] == 0 && db.choices[1] == 0 && !isSpawned)
            {
                
                string[] list = GeneretionBloks(db.d1);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                { 
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString())){
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;

            }
            else if(db.choices[0] == 0 && db.choices[1] == 1 && !isSpawned)
            {   
                // d2
                string[] list = GeneretionBloks(db.d2);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                {
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString()))
                    {
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;
            }
            else if (db.choices[0] == 0 && db.choices[1] == 2 && !isSpawned)
            {
                // d3
                string[] list = GeneretionBloks(db.d3);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                {
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString()))
                    {
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;

            }
            else if (db.choices[0] == 0 && db.choices[1] == 3 && !isSpawned)
            {
                // d4
                string[] list = GeneretionBloks(db.d4);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                {
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString()))
                    {
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;

            }
            // 4
            else if (db.choices[0] == 0 && db.choices[1] == 4 && !isSpawned)
            {
                // d4
                string[] list = GeneretionBloks(db.d5);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                {
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString()))
                    {
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;

            }
            // 5
            else if (db.choices[0] == 0 && db.choices[1] == 5 && !isSpawned)
            {
                // d4
                string[] list = GeneretionBloks(db.d6);
                bool isAlready;
                Dictionary<string, bool> bloksDict = new Dictionary<string, bool>();
                for (int i = 0; i < list.Length; i++)
                {
                    if (PlayerPrefs.HasKey(db.choices[1].ToString() + i.ToString()))
                    {
                        isAlready = true;
                    }
                    else
                    {
                        isAlready = false;
                    }
                    bloksDict[list[i]] = isAlready;
                }
                LoadMenu(bloksDict);
                isSpawned = true;
                isDone = true;

            }
            else if (db.choices[0] == 0 && db.choices[1] == 6 && !isSpawned)
            {
               
                db.choices.Add(0);
                isSelected = true;
                isSpawned = true;
                isDone = true;

            }

        }
        if (db.choices.Count == 3 && !isDone)
        {
            if (!isTestActive)
            {
                toggleSwitch.SetActive(false);
                GameObject.Find("Info").SetActive(false);
                SceneManager.LoadScene("PlayGround", LoadSceneMode.Additive);
                isTestActive = true;
            }
            isDone = true;
        }
    }
    
    public void LoadMenu(Dictionary<string, bool> dict)
    {
        int step = 100;
        int height = 0;
        int i = 0;
        
        foreach (string element in dict.Keys)
        {
            GameObject parentObj = GameObject.Find("Content");
            GameObject button = Instantiate(buttonPrefab, new Vector3(screenWidth / 2, screenHeight / 2 + height + dict.Count * 50, 0), Quaternion.identity, parentObj.transform);
            height -= step;
            button.GetComponent<Button>().name = i.ToString();
            if (dict[element] == true)
            {
                button.GetComponentInChildren<Text>().color = new Color(0.5f, 0.5f, 0.5f);
            }

            i++;
            button.GetComponentInChildren<Text>().text = element;

        }
    }
    
    public void ClearList()
    {
        Button[] buttons = GameObject.Find("Canvas").GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            
            GameObject button = GameObject.Find(buttons[i].name.ToString());
            
            if (button.name != "SwitchON" && button.name != "SwitchOFF" && button.name != "ClearProgress")
            {
                Destroy(button);
            }

        }
    }

    string[] GeneretionBloks(Dictionary<string, string> dict)
    {
        float number = numberOfWords;
        int n = Mathf.CeilToInt(dict.Count / number);
        string[] list = new string[n];
        for (int i = 1; i <= list.Length; i++)
        {
            int j = i - 1;
            if (i % 10 == 1) list[j] = i.ToString() + "st block";
            else if (i % 10 == 2) list[j] = i.ToString() + "nd block";
            else if (i % 10 == 3) list[j] = i.ToString() + "st block";
            else list[j] = i.ToString() + "th block";
        }
        return list;
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
