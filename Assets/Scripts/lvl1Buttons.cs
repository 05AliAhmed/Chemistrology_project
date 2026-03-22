using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class lvl1Buttons : MonoBehaviour
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] int amendScore = 10; // in inspector can change the value
    int score; // keeping the score variable.
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text highScoreTxt;

    public void ScoreSystem() // will late be connected with shooting system to count scores
    {
        score += amendScore;
        scoreTxt.text = score.ToString();
        if(score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreTxt.text = score.ToString();    
        }
        Debug.Log(score);
    }
    public void BackOption() // will late be replaced with settings button
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton() // is used for pasusing the game
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() // for resuming the game
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void Start()
    {
        pausemenu.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        
    }
}
