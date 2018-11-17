using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject gameOverPanel;
    public Text currentScoreText;

    public Text highScoreText;

    private int currentScore;

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Lost()
    {
        StartCoroutine(LostCoroutine());
    }

    private IEnumerator LostCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameOverPanel!=null)
            gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        currentScore++;
        if (currentScore>GamePreferences.GetHighScore())
        {
            GamePreferences.SetHighScore(currentScore);
            if (highScoreText!=null)
            {
                highScoreText.text=GamePreferences.GetHighScore().ToString();
            }
        }

        SetScore();
    }

    private void SetScore()
    {
        currentScoreText.text=currentScore.ToString();
    }

    private void Init()
    {
        currentScore=0;
        currentScoreText.text="0";

        highScoreText.text=GamePreferences.GetHighScore().ToString();
    }
}