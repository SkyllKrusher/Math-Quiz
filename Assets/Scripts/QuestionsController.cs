using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionsController : MonoBehaviour
{
        [SerializeField] private TextMeshProUGUI statementText;
        [SerializeField] private TextMeshProUGUI[] optionTexts;
        private Questions questions;
        private int currentQuestion;
        private int totalQuestions;
        private string dataPath;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            currentQuestion = 0;
            DisplayQuestion(currentQuestion);
        }

        private void NextQuestion()
        {
            DisplayQuestion(currentQuestion+1);
        }


        #region ----------- UI Methods -------------------

        private void DisplayQuestion(int questionNumber)
        {
            statementText.text = questions.questionsList[questionNumber].GetStatement();
            DisplayOptions(questionNumber);
        }

        private void DisplayOptions(int questionNumber)
        {
            for(int i=0; i<4; i++)
            {
                optionTexts[i].text = questions.questionsList[questionNumber].GetOption(i);
            }
        }
        #endregion

        #region -------------------- Parse Methods------------

        private void ParseQuestions()
        {
            int i=0;
            TextAsset questionsTextAsset = (TextAsset) Resources.Load(dataPath);
            Debug.Log("Questions Text: " + questionsTextAsset.text);
            Questions questions = JsonUtility.FromJson<Questions>(questionsTextAsset.ToString());
            
            Debug.Log(questions.questionsList[0].GetAnswer());
        }
        #endregion

}
