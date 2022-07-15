using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuView : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private TMP_Dropdown difficultyLevelDropdown;

    void Awake()
    {
        playButton.onClick.AddListener(() => OnClickPlay());        
    }

    private void OnClickPlay()
    {
        GameManager.Instance.SetDifficultyLevel(difficultyLevelDropdown.value+1);
        Debug.Log(GameManager.Instance.difficultyLevel);
        GameManager.Instance.LoadGameScene();
    }
}
