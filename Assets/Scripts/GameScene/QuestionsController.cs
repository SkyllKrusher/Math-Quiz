using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionsController : MonoBehaviour
{
    #region  ---------------------- Variables -----------------------
    [SerializeField] private TextMeshProUGUI statementText;
    [SerializeField] private List<Option> options;
    // [SerializeField] private GameObject touchBlocker;
    [Space]
    public Sprite unansweredSprite;
    public Sprite correctSprite;
    public Sprite incorrectSprite;
    private GameView gameView;
    private List<Question> unansweredQuestions;
    private int currentQuestionIndex;
    private bool isAnsweringEnabled = true;
    // private int totalQuestions;
    #endregion ---------------------------------------------------

    private void Awake()
    {
        gameView = FindObjectOfType<GameView>();
    }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // StopAllCoroutines();
        currentQuestionIndex = 0;
        unansweredQuestions = new List<Question>();
        if(!QuestionsManager.Instance.IsParsed)
        {
            return;
        }
        foreach (Question ques in QuestionsManager.Instance.questions.questionsList)
        {
            if(ques.difficulty == GameManager.Instance.difficultyLevel)
            {
                unansweredQuestions.Add(ques);
            }
        }
        GameManager.Instance.SetTotalQuestionsInCurrentRound(unansweredQuestions.Count);
        DisplayQuestion(currentQuestionIndex); //Display first question
    }

    private void EndCurrentQuestion()
    {
        if(currentQuestionIndex+1<unansweredQuestions.Count)
        {
            DisplayQuestion(++currentQuestionIndex); //display next
        }
        else
        {
            gameView.GameOver();
        }
    }


    #region ----------- UI Methods -------------------

    private void DisplayQuestion(int questionNumber)
    {
        isAnsweringEnabled = true;
        Debug.Log(questionNumber);
        statementText.text = unansweredQuestions[questionNumber].statement;
        UpdateOptions(questionNumber);
    }

    private void UpdateOptions(int questionNumber)
    {
        for(int i=0; i<4; i++)
        {
            string optionText = unansweredQuestions[questionNumber].options[i];
            Debug.Log(optionText);
            options[i].InitOption(optionText);
        }
    }

    public void OnClickAnyOption(int selectedOption)
    {
        if(!isAnsweringEnabled)
        {
            return;
        }
        isAnsweringEnabled = false;
        if(selectedOption == unansweredQuestions[currentQuestionIndex].answer) //Correctly answered
        {
            options[selectedOption].ShowAsCorrect();
            GameManager.Instance.IncreaseScore();
            Debug.Log("Correct answer");
        }
        else                                                                    // Incorrectly answered
        {
            options[selectedOption].ShowAsIncorrect();
            Debug.Log("incorrect");
            StartCoroutine(DelayedDisplayCorrectOption());
        }
        StartCoroutine(DelayedEndCurrentQuestion());
    }

    private IEnumerator DelayedDisplayCorrectOption() //display correct answer after delay
    {
        // touchBlocker.SetActive(true);
        options[unansweredQuestions[currentQuestionIndex].answer].ShowAsCorrect();
        yield return new WaitForSeconds(1f);
        // touchBlocker.SetActive(false);
    }

    private IEnumerator DelayedEndCurrentQuestion()
    {
        // touchBlocker.SetActive(true);
        yield return new WaitForSeconds(5f);
        // touchBlocker.SetActive(false);
        EndCurrentQuestion();
    }
    #endregion -------------------------------

}
