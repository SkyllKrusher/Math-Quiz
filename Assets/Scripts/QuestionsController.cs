using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionsController : MonoBehaviour
{
        [SerializeField] private TextMeshProUGUI statementText;
        [SerializeField] private TextMeshProUGUI[] optionTexts;
        private List<Question> unansweredQuestions;
        private int currentQuestion;
        // private int totalQuestions;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            currentQuestion = 0;
            unansweredQuestions = new List<Question>();
            if(QuestionsManager.Instance.IsParsed)
            {
                foreach (Question ques in QuestionsManager.Instance.questions.questionsList)
                {
                    // if(ques.difficulty = selectedDifficulty)
                    unansweredQuestions.Add(ques);
                }
            }
            DisplayQuestion(currentQuestion);
        }

        private void NextQuestion()
        {
            DisplayQuestion(currentQuestion+1);
        }


        #region ----------- UI Methods -------------------

        private void DisplayQuestion(int questionNumber)
        {
            statementText.text = "yo";
            // questions.questionsList[questionNumber].statement;
            UpdateOptions(questionNumber);
        }

        private void UpdateOptions(int questionNumber)
        {
            for(int i=0; i<4; i++)
            {
                optionTexts[i].text = unansweredQuestions[questionNumber].options[i];
            }
        }
        #endregion

}
