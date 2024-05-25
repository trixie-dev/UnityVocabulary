using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public static class Storage
{
    public static QuestionModel[] Words;
    public static TopicModel[] VocabularyTopics;
    private static List<TopicModel> _vocabularyTopicSaves = new List<TopicModel>();
    
    
    private static int _vocabularyTopicSize = 50;
    

    public static void Initialize()
    {
        Words = JsonConvert.DeserializeObject<QuestionModel[]>(Resources.Load<TextAsset>("WordsData").ToString());
        _vocabularyTopicSaves = LoadTopicInfo();
    }


    public static void SaveTopicInfo(TopicModel data)
    {
        _vocabularyTopicSaves.Add(data);
        PlayerPrefs.SetString("SaveData", JsonConvert.SerializeObject(_vocabularyTopicSaves));
    }
    
    public static List<TopicModel> LoadTopicInfo()
    {
        int topicsCount = (int)Math.Ceiling((float)Words.Length / _vocabularyTopicSize);
        VocabularyTopics = new TopicModel[topicsCount];
        
        for (int i = 0; i < topicsCount; i++)
        {
            VocabularyTopics[i] = new TopicModel(0, i, 0, 0, 0, false, false);
        }
        _vocabularyTopicSaves = JsonConvert.DeserializeObject<List<TopicModel>>(PlayerPrefs.GetString("SaveData"));
        if (_vocabularyTopicSaves == null) _vocabularyTopicSaves = new List<TopicModel>();
        
        foreach (var saveData in _vocabularyTopicSaves)
        {
            VocabularyTopics[saveData.Index] = saveData;
        }
        return _vocabularyTopicSaves;
    }
    
    public static List<QuestionModel> GetVocabularyWords(int topicIndex)
    {
        List<QuestionModel> words = new List<QuestionModel>();
        int start = topicIndex * 50;
        int end = (topicIndex + 1) * 50;
        if (end > Words.Length) end = Words.Length;
        for (int i = start; i < end; i++)
        {
            words.Add(Words[i]);
        }
        return words;
    }
    
    
        
    
    
    
}
