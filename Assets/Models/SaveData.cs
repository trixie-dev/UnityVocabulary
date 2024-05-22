using System;

[Serializable]
public class SaveData
{
    public int Type { get; set; }
    public int TopicIndex { get; set; }
    public int AttemptsToComplete { get; set; }
    public int Accuracy { get; set; }
    public bool IsCompleted { get; set; }
    
    public SaveData(int type, int topicIndex, int attemptsToComplete, int accuracy, bool isCompleted)
    {
        Type = type;
        TopicIndex = topicIndex;
        AttemptsToComplete = attemptsToComplete;
        Accuracy = accuracy;
        IsCompleted = isCompleted;
    }
}