using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class ScoreSystem
{
    public int Score = 0;
    public TMP_Text scoreText;

    public void InitialiseScore()
    {
        Score = -1;
    }

    public void IncrementScore()
    {
        Score += 1;
    }

    

}
