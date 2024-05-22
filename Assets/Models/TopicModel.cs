using System;

[Serializable]
public class TopicModel
{
    public int Type { get; set; }
    public int Index { get; set; }
    public int AttemptsToComplete { get; set; }
    public int Accuracy { get; set; }
    public bool IsCompleted { get; set; }
    
    public TopicModel(int type, int index, int attemptsToComplete, int accuracy, bool isCompleted)
    {
        Type = type;
        Index = index;
        AttemptsToComplete = attemptsToComplete;
        Accuracy = accuracy;
        IsCompleted = isCompleted;
    }
}