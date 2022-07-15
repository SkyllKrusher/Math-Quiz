using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ----------------------------------------- Init Singleton ----------------------------------------
    public static GameManager Instance {get; private set;}

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

    private static string GameSceneName = "GameScene";
    private static string MainMenuSceneName = "MainMenuScene";
    public int difficultyLevel {private set; get;}

    public int score { private set; get;}
    public int totalQuestionsInCurrentRound { private set; get;}

    public void SetDifficultyLevel(int level)
    {
        difficultyLevel = level;
        LoadGameScene();
    }

    public void SetTotalQuestionsInCurrentRound(int numberOfQuestions)
    {
        totalQuestionsInCurrentRound = numberOfQuestions;
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void InitGameScene()
    {
        score = 0;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameSceneName);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(MainMenuSceneName);
        InitGameScene();
    }


}
