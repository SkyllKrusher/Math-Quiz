using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMPro.TextMeshProUGUI gameOverScoreText;
    [SerializeField] private Button goToMenuBtn;

    void Awake()
    {
        goToMenuBtn.onClick.AddListener(()=>OnGoToMenuBtnClick());
    }

    private void OnGoToMenuBtnClick()
    {
        GameManager.Instance.LoadMainMenuScene();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "SCORE: " + GameManager.Instance.score + " / " + GameManager.Instance.totalQuestionsInCurrentRound;
    }


}
