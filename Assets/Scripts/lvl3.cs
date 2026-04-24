using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvl3 : MonoBehaviour
{ 
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine; // progressbar
    [SerializeField] GameObject nxtLvlBtn; // ref to next lvl button if score > score needed yo pass the lvl.
    [SerializeField] int amendScore = 10; // in inspector can change the value
    [SerializeField] int loseScore = 50; // in inspector can change the value
    [SerializeField] int comboScore;
    [SerializeField] float scoreToPass; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl 
    // [SerializeField] TMP_Text passScoreTxt; // txt ref for score needed to pass the lvl shown while playing 
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    // Scene currentScene;
    public bool gameEnd;
    // bool factScreenShown = false;
    // public Image progressBar;
    public Image star1;
    public Image star2;
    public Image star3;
    public int pnt1;
    public int pnt2;
    public int pnt3;
    public int score; // keeping the score variable.
    // int highScore;
    float passScore;
    // int scnIndex;
    public int targetCount;

    public bool pauseInputs;

    public List<GameObject> groupOfTargets;

    public void ComboSystem() // awarding combo points
    {
        targetCount++;
        if(targetCount > 2) // checking if target hit are grater than 2
        {
            score += comboScore;  // then score plus comboscore
            scoreTxt.text = score.ToString();
            Debug.Log(score); // testing
        }
    }
    public void ScoreSystem() // will late be connected with shooting system to count scores | Score Button
    {
        Debug.Log("score system");
        score += amendScore;
        scoreTxt.text = score.ToString();
        factScrScoreTxt.text = score.ToString();
        passScore = scoreToPass - score; 
        if(passScore < 0)
        {
            passScore = 0;
        }
        factScrScoreNeededTxt.text = passScore.ToString();
        if(score > PlayerPrefs.GetInt("Highscore3",0)) // if score is greater than H.S, 0 is there because at start high score is 0.
        {
            PlayerPrefs.SetInt("Highscore3", score); // setting Highscore to be the score continously 
            highScoreTxt.text = score.ToString();            
        }
    }
    public void LoseScore()
    {
        score -= loseScore;
        if(score < 0)
        {
            score = 0;
        }
        scoreTxt.text = score.ToString();
    }
    void DisplayStars()
    {
        if(score >= pnt1 && score < pnt2)
        {
            Debug.Log("star 1");
            star1.gameObject.SetActive(true);
        }
        else if(score >= pnt2 && score < pnt3)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
        }
        else if(score >= pnt3)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
        else
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
        }
        
    }

    public void ChangeScene(int _sceneindex)
    {
        SceneManager.LoadScene(_sceneindex);
        Time.timeScale = 1f;
    }
    public void PauseButton() // is used for pasusing the game | Settings button
    {
        pauseInputs = true;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() // for resuming the game
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        pauseInputs = false;
    }
    public void FactScreenLvl1()
    {
        if(gameEnd == true)
        {
            // factScreenShown = true;
            // Debug.Log("Game end is true");
            factScreen.SetActive(true);
            Time.timeScale = 0f;
            if(score < scoreToPass)
            {
                // levelMenuScript.lvl2.SetActive(false);
                GameManager.instance.level2Unlocked = false;
                nxtLvlBtn.SetActive(false);
                scoreNeededLine.SetActive(true);
            }
            else
            {
                // levelMenuScript.lvl2.SetActive(true);
                GameManager.instance.level2Unlocked = true;
                nxtLvlBtn.SetActive(true);
                scoreNeededLine.SetActive(false);
            }
            DisplayStars();
        }        
    }

    void Start()
    {
        pausemenu.SetActive(false);
        factScreen.SetActive(false);
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore3", 0).ToString();
        Time.timeScale = 1f;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
    }

    void Update()
    {
        FactScreenLvl1(); // can use if statement to check scn and display its fact0scr

    }
}
