using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string statement;
    public string[] options;
    public int answer; //0 to 3
    public int difficultyLevel; // (0 to 2)easy, medium hard
}