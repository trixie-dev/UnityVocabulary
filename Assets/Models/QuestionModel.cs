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
    
    public string GetWorld(bool isEnglishMode)
    {
        return isEnglishMode ? Word : Translation;
    }
    
    public string GetTranslation(bool isEnglishMode)
    {
        return isEnglishMode ? Translation : Word;
    }
}