using System;

[Serializable]
public class WordStatModel
{
    public int Id { get; set; }
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public int WordKnowledge { get; set; }
}