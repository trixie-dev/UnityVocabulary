using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    public Text questionWord;
    public Text answerWord;
    public Text score;

    DB db;

    public GameObject nextButton;
    public GameObject keepButton;
    public Button openButton;

    bool isQuestionWord;
    bool isAnswerWord = true;
    bool isProgramStart = false;
    bool isLastWord;
    List<string> keys = new List<string>();
    Dictionary<string, string> dict = new Dictionary<string, string>();

    int maxLen;
    string key;


    int numberOfIncorrect = 0;

    // Start is called before the first frame update
    void Start()
    {
        db = GameObject.Find("MenuManager").GetComponent<DB>();
        dict = db.data;
        maxLen = dict.Count;
        foreach (string key in dict.Keys)
        {
            keys.Add(key);
        }
        
        questionWord.enabled = false;
        answerWord.enabled = false;
        nextButton.SetActive(false);
        keepButton.SetActive(false);
        score.enabled = false;
        openButton.GetComponentInChildren<Text>().text = "Start";
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int lenght = dict.Count;
        score.text = (maxLen - lenght - 1).ToString() + " / " + maxLen.ToString();
        if (lenght == 0 && isLastWord)
        {
            questionWord.enabled = false;
            answerWord.enabled = true;
            score.text = "Your accuracy: " + Math.Round((maxLen * 100f / (maxLen + numberOfIncorrect)), 1).ToString() + "%";
            answerWord.text = "press Exit to go to the main menu";
            nextButton.SetActive(false);
            keepButton.SetActive(false);
            openButton.GetComponentInChildren<Text>().enabled = false;

            SaveProgress();

            
        }
        if (Input.GetKeyDown(KeyCode.Space) && isAnswerWord)
        { 
            NextWord();
            
        }
        if (Input.GetKeyDown(KeyCode.E) && isQuestionWord == true)
        {
            OpenAnswer();
        }
        if (Input.GetKeyDown(KeyCode.X) && isQuestionWord == true)
        {
            KeepWord();
        }

        //questionWord.text = 
    }

    public void GenerationWords(int lenght)
    {
        key = keys[UnityEngine.Random.Range(0, lenght)];
        questionWord.text = key;
        answerWord.text = dict[key];
        answerWord.enabled = false;
        isQuestionWord = true;
        isAnswerWord = false;

    }
    public void OpenAnswer()
    {
        answerWord.enabled = true;
        isQuestionWord = false;
        isAnswerWord = true;
    }
    public void NextWord()
    {
        int lenght = dict.Count;
        
        if (lenght != 0)
        {
            GenerationWords(lenght);
            dict.Remove(key);
            keys.Remove(key);
            
            print(key);   
        }
        if (lenght == 0)
        {
            isLastWord = true;
        }
        

            
    }
    public void KeepWord()
    {
        numberOfIncorrect++;
        int lenght = dict.Count;
        if (lenght != 0)
        {
            GenerationWords(lenght);
        }
    }
    public void StartProgram()
    {
        if (!isProgramStart)
        {
            nextButton.SetActive(true);
            keepButton.SetActive(true);
            score.enabled = true;
            openButton.GetComponentInChildren<Text>().text = "Open";
            NextWord();
            questionWord.enabled = true;
            isProgramStart = true;
        }
        
        
    }
    public void LoadMainMenu()
    {
        
        
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
    void SaveProgress()
    {
        string keyOfSave = db.choices[1].ToString() + db.choices[2].ToString();
        PlayerPrefs.SetInt(keyOfSave, 1);
        PlayerPrefs.Save();
    }
}   
