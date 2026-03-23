
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;


public class lvl1Buttons : MonoBehaviour
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] int amendScore = 10; // in inspector can change the value
    [SerializeField] int loseScore = 50; // in inspector can change the value
    [SerializeField] int targetsHit; // mannualy hitting and checking checking if all targets been hit | Number of electron in atom
    [SerializeField] int totalTarget; // number of electron is an atom per level
    [SerializeField] int scoreToPassLOne; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text highScoreTxt;
    int score; // keeping the score variable.
    int highScore;


    public void ScoreSystem() // will late be connected with shooting system to count scores | Score Button
    {
        score += amendScore;
        scoreTxt.text = score.ToString();
        highScore = score; // testing purpose not working remove highscore int and this line later.
        if(score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreTxt.text = score.ToString();   
        }
        Debug.Log(score);
    }

    public void LoseScore()
    {
        score -= loseScore;
        scoreTxt.text = score.ToString();
    }
    public void BackOption() // will late be replaced with settings button | bact to main menu button 
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton() // is used for pasusing the game | Settings button
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() // for resuming the game
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LevelMenu() // to level menu
    {
        SceneManager.LoadScene(2);
    }
    void Start()
    {
        pausemenu.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        if(targetsHit == totalTarget)
        {
            //pop fact screen, display score, high score | In proper play
            if(score < scoreToPassLOne)
            {
                Debug.Log($"You need {scoreToPassLOne - score} more points to proceed");
                Debug.Log($"{score}");
                Debug.Log($"{highScore}");
            }
            else
            {
                Debug.Log("Here is the fact");
                Debug.Log($"{score}");
                Debug.Log($"{highScore}");
                // display next button | next button.setactive(true);               
            }
        }
        else
        {
            Debug.Log("Not yet");
        }
    }
}
