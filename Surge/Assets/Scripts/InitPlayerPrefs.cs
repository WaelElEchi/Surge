using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerPrefs : MonoBehaviour
{
    private void OnEnable()
    {
        IsFirstTime();
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void IsFirstTime()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            //other inits

            GamePreferences.SetHighScore(0);
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }
}