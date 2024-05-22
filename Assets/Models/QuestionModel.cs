using System;

[Serializable]
public class QuestionModel
{
    public int Type { get; set; }
    public int Id { get; set; }
    public string Word { get; set; }
    public string Translation { get; set; }
    
    public void Swap()
    {
        (Word, Translation) = (Translation, Word);
    }
}