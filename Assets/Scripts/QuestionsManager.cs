using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    #region ----------------------------------------- Init Singleton ----------------------------------------
    public static QuestionsManager Instance {get; private set;}

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion -----------------------------------------------------------------------------------------------

    #region ------------------------------------- Variables ------------------------------------------
    private string questionsDataFilePath = "QuestionsDataFile";
    private bool isParsed = false;
    public Questions questions;
    public bool IsParsed { get { return isParsed; } }

    #endregion -----------------------------------------------------------------------------------------------
    #region -------------------------------------- Private Methods -----------------------------------------
    private void Start()
    {
        QuestionsManagerInit();
    }

    private void ParseQuestions()
    {
        TextAsset questionsTextAsset = (TextAsset) Resources.Load(questionsDataFilePath);
        Debug.Log("Questions Text: " + questionsTextAsset.text);
        questions = JsonUtility.FromJson<Questions>(questionsTextAsset.ToString());
        isParsed = true;
        // Debug.Log(questions.questionsList.Count);
    }

    #endregion -----------------------------------------------------------------------------------------------

    #region -------------------------------------- Public Methods -----------------------------------------

    public void QuestionsManagerInit()
    {
        ParseQuestions();
        // LoadLevel(currentLevel);
    }

    #endregion -----------------------------------------------------------------------------------------------
}