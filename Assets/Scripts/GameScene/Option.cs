using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    [Range(0,3)]
    public int optionIndex;
    private Button optionButton;
    private QuestionsController questionsController;
    private TextMeshProUGUI displayText;
    
    private Image optionBgImage;

    private void Awake()
    {
        questionsController = FindObjectOfType<QuestionsController>();
        optionBgImage = GetComponent<Image>();
        displayText = GetComponentInChildren<TextMeshProUGUI>();
        optionButton = GetComponent<Button>();
        optionButton.onClick.AddListener(OnClickButton);
    }
    private void OnClickButton()
    {
        questionsController.OnClickAnyOption(optionIndex);
    }

    public void InitOption(string optionText)
    {
        optionBgImage.sprite = questionsController.unansweredSprite;
        displayText.text = optionText;
    }

    public void ShowAsCorrect()
    {
        optionBgImage.sprite = questionsController.correctSprite;
    }
    public void ShowAsIncorrect()
    {
        optionBgImage.sprite = questionsController.incorrectSprite;
    }
}
