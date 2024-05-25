using System;

[Serializable]
public class TopicModel
{
    public int Type { get; set; }
    public int Index { get; set; }
    public int AttemptsToComplete { get; set; }
    public int EnglishAccuracy { get; set; }
    public int NativeAccuracy { get; set; }
    public bool IsCompletedFromEnglish { get; set; }
    public bool IsCompletedFromNative { get; set; }
    
    public TopicModel(int type, int index, int attemptsToComplete, int englishAccuracyEnglish, int nativeAccuracy, bool isCompletedEnglish, bool isCompletedNative)
    {
        Type = type;
        Index = index;
        AttemptsToComplete = attemptsToComplete;
        EnglishAccuracy = englishAccuracyEnglish;
        NativeAccuracy = nativeAccuracy;
        IsCompletedFromEnglish = isCompletedEnglish;
        IsCompletedFromNative = isCompletedNative;
    }
}