using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Serialization;

public class DB : MonoBehaviour
{
    public int method;
    public Dictionary<string, string> data;
    // ???????
    
    // from Resources WordsData.json to questionModels
    public QuestionModel[] QuestionModels;
    public List<int> choices = new List<int>();
    List<string> keys = new List<string>();

    bool isDone = false;

    // Update is called once per frame
    void Update()
    {
        if (choices.Count == 3)
        {
            
            if (choices[0] == 0 && choices[1] == 0 && !isDone)
            {

                //CreateData(d1);
                isDone = true;

            }
        }
        
    }

    Dictionary<string, string> Gen(QuestionModel[] questionModels)
    {
        int numberOfWords = GameObject.Find("MenuManager").GetComponent<MenuScript>().numberOfWords;
        int start = choices[2] * numberOfWords;
        int end = (choices[2]+1) * numberOfWords;
        Dictionary<string, string> tmp = new Dictionary<string, string>();
        if (keys.Count < end) end = keys.Count;
        for(int i = start; i < end; i++)
        {
            //tmp[keys[i]] = dict[keys[i]];
            
        }
        return tmp;
    }
    
    Dictionary<string, string> Reverse(Dictionary<string, string> dict)
    {
        Dictionary<string, string> tmp = new Dictionary<string, string>();
        foreach (string key in dict.Keys)
        {
            if (tmp.ContainsKey(dict[key]))
            {
                string newKey = dict[key] + " ";
                tmp[newKey] = key;
            }
            else tmp[dict[key]] = key;
        }
        return tmp;
    }
    void CreateData(Dictionary<string, string> dict)
    {
        foreach (string key in dict.Keys)
        {

            keys.Add(key);
        }


        if (method == 1)
        {
            //data = Gen(dict);
        }
        else if (method == 0)
        {
            //data = Reverse(Gen(dict));
        }

    }
    void RandomData(Dictionary<string, string> tmp, Dictionary<string, string> dict)
    {
        List<string> keys0 = new List<string>();
        foreach (string key in dict.Keys)
        {
            keys0.Add(key);
        }
        int index = UnityEngine.Random.Range(0, keys0.Count);
        if (tmp.ContainsKey(keys0[index]))
        {
            string newKey = keys0[index] + " ";
            tmp.Add(newKey, dict[keys0[index]]);
        }
        else tmp.Add(keys0[index], dict[keys0[index]]);



    }
    

}
