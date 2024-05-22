using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionManager : Tab
{
    private List<QuestionModel> _questions = new List<QuestionModel>();
    
    public TextMeshProUGUI ProgressText;
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI AnswerText;
    public TextMeshProUGUI TimeText;

    public GameObject ShowButtonObj;
    public GameObject CorrectButtonObj;
    public GameObject WrongButtonObj;
    
    private QuestionModel _currentQuestion;
    private List<QuestionModel> _previousQuestions = new List<QuestionModel>();
    private TopicModel _currentTopic;
    
    private int _initialQuestionCount;
    
    private int _correctAnswers;
    private int _attempts = 1;
    private int _timeInSeconds = 0;
    private int accuracy => (int)(((_correctAnswers + 1) / (float)_attempts) * 100);

    private string _progressText =>
        $"Pr: {_correctAnswers}/{_initialQuestionCount}    At: {_attempts - 1}    Ac: {accuracy}%";
    

    public void StartSession(TopicModel topic, bool isReverse)
    {
        _currentTopic = topic;
        _questions = Storage.GetVocabularyWords(topic.Index);
        _initialQuestionCount = _questions.Count;
        if (isReverse)
        {
            foreach (var question in _questions)
            {
                question.Swap();
            }
        }
        ShowButtonObj.SetActive(true);
        CorrectButtonObj.SetActive(false);
        WrongButtonObj.SetActive(false);

        ShowQuestion();
        InvokeRepeating(nameof(UpdateTime), 0, 1);
    }
    
    public void ShowQuestion()
    {
        ProgressText.text = _progressText;
        _currentQuestion = GetRandomQuestion();
        
        if (_currentQuestion == null)
        {
            FinishSession();
        }
        else
        {
            QuestionText.text = _currentQuestion.Word;
            AnswerText.text = "";
        }
    }
    
    private void FinishSession()
    {
        QuestionText.text = "";
        AnswerText.text = "Completed";
        Invoke(nameof(MainMenu), 3);
        CancelInvoke(nameof(UpdateTime));
        SendStatistic();
    }

    private void SendStatistic()
    {
        _currentTopic.IsCompleted = true;
        _currentTopic.AttemptsToComplete = _attempts - 1;
        _currentTopic.Accuracy = accuracy;
        Storage.SaveTopicInfo(_currentTopic);
    }

    private void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }

    public void ShowAnswer()
    {
        AnswerText.text = _currentQuestion.Translation;
        SwapControlButtons();
    }
    
    public void Answer(bool isCorrect)
    {
        if (isCorrect)
        {
            _questions.Remove(_currentQuestion);
            _correctAnswers++;
        }
        else
        {
            if (_previousQuestions.Count > 3)
            {
                _previousQuestions.RemoveAt(0);
            }
            if(!_previousQuestions.Contains(_currentQuestion))
                _previousQuestions.Add(_currentQuestion);
        }
        _attempts++;
        SwapControlButtons();
        ShowQuestion();
    }
    
    private QuestionModel GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            return null;
        }
        int index = Random.Range(0, _questions.Count);
        
        if(_questions.Count > 5 && _previousQuestions.Contains(_questions[index]))
            return GetRandomQuestion();
        
        return _questions[index];
    }

    private void SwapControlButtons()
    {
        if (ShowButtonObj.activeSelf)
        {
            ShowButtonObj.SetActive(false);
            CorrectButtonObj.SetActive(true);
            WrongButtonObj.SetActive(true);
        }
        else
        {
            ShowButtonObj.SetActive(true);
            CorrectButtonObj.SetActive(false);
            WrongButtonObj.SetActive(false);
        }
    }
    
    private void UpdateTime()
    {
        TimeText.text = $"{_timeInSeconds / 60} : {_timeInSeconds % 60}";
        _timeInSeconds++;
        // format time
    }
}