using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    [SerializeField] private string statement;
    [SerializeField] private string[] options;
    [SerializeField] private int answer;

    public string GetStatement()
    {
        return statement;
    }
    
    public string GetOption(int index)
    {
        return options[index];
    }

    public int GetAnswer()
    {
        return answer;
    }
}