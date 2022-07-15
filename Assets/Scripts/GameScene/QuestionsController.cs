using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionsController : MonoBehaviour
{
    #region  ---------------------- Variables -----------------------
    [SerializeField] private TextMeshProUGUI statementText;
    [SerializeField] private List<Option> options;
    [SerializeField] private GameObject touchBlocker;
    [Space]
    public Sprite unansweredSprite;
    public Sprite correctSprite;
    public Sprite incorrectSprite;
    private List<Question> unansweredQuestions;
    private int currentQuestionIndex;
    // private int totalQuestions;
    #endregion ---------------------------------------------------

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            // StopAllCoroutines();
            currentQuestionIndex = 0;
            unansweredQuestions = new List<Question>();
            if(QuestionsManager.Instance.IsParsed)
            {
                foreach (Question ques in QuestionsManager.Instance.questions.questionsList)
                {
                    // if(ques.difficulty = selectedDifficulty)
                    unansweredQuestions.Add(ques);
                }
            DisplayQuestion(currentQuestionIndex);
            }
        }

        private void NextQuestion()
        {
            DisplayQuestion(++currentQuestionIndex);
        }


        #region ----------- UI Methods -------------------

        private void DisplayQuestion(int questionNumber)
        {
            Debug.Log(questionNumber);
            statementText.text = "yo";
            // questions.questionsList[questionNumber].statement;
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
            if(selectedOption == unansweredQuestions[currentQuestionIndex].answer)
            {
                options[selectedOption].ShowAsCorrect();
                Debug.Log("Correct answer");
                StartCoroutine(DelayedNextQuestion());
            }
            else
            {
                options[selectedOption].ShowAsIncorrect();
                Debug.Log("incorrect");
                StartCoroutine(DelayedDisplayCorrectOption());
                StartCoroutine(DelayedNextQuestion());
                //display correct after delay
            }
        }

        private IEnumerator DelayedDisplayCorrectOption()
        {
            touchBlocker.SetActive(true);
            options[unansweredQuestions[currentQuestionIndex].answer].ShowAsCorrect();
            yield return new WaitForSeconds(1f);
            touchBlocker.SetActive(false);
        }

        private IEnumerator DelayedNextQuestion()
        {
            touchBlocker.SetActive(true);
            yield return new WaitForSeconds(3f);
            touchBlocker.SetActive(false);
            NextQuestion();
        }
        #endregion -------------------------------

}
