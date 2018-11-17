using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferences : MonoBehaviour
{
    public static string HighScore = "HighScore";

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);
    }

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScore, score);
    }
}