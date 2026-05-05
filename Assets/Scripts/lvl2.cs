using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class lvl2 : lvlsManagerbase
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine; // progressbar
    [SerializeField] GameObject nxtLvlBtn; // ref to next lvl button if score > score needed yo pass the lvl.
    // [SerializeField] int amendScore = 10; // in inspector can change the value
    // [SerializeField] int loseScore = 50; // in inspector can change the value
    // [SerializeField] int comboScore;
    [SerializeField] int scoreToPass; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl 
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    public bool gameEnd;
    public Image star1;
    public Image star2;
    public Image star3;
    public int pnt1;
    public int pnt2;
    public int pnt3;
    // public int score;
    int passScore;
    // public int targetCount;
    public bool pauseInputs;
    public List<GameObject> groupOfTargets;

    public override void ComboSystem() // awarding combo points
    {
        // targetCount++;
        // if(targetCount > 2) // checking if target hit are grater than 2
        // {
        //     score += comboScore;  // then score plus comboscore
            scoreTxt.text = score.ToString();
            // Debug.Log(score); // testing
        // }
    }
    public override void ScoreSystem() // will late be connected with shooting system to count scores | Score Button
    {
        base.ScoreSystem();
        // Debug.Log("score system");
        // score += amendScore;
        scoreTxt.text = score.ToString();
        factScrScoreTxt.text = score.ToString();
        passScore = scoreToPass - score; 
        // highScore = score; // testing purpose not working remove highscore int and this line later.
        if(passScore < 0)
        {
            passScore = 0;
        }
        // passScoreTxt.text = passScore.ToString();
        factScrScoreNeededTxt.text = passScore.ToString();
        if(score > PlayerPrefs.GetInt("Highscore2",0)) // if score is greater than H.S, 0 is there because at start high score is 0.
        {
            PlayerPrefs.SetInt("Highscore2", score); // setting Highscore to be the score continously 
            highScoreTxt.text = score.ToString();
            // passScoreTxt.text = passScore.ToString();            
        }
        // Debug.Log(score); // testing
        // Debug.Log("CONNECTED"); // testing
    }
    public override void LoseScore()
    {
        base.LoseScore();
        // score -= loseScore;
        // if(score < 0)
        // {
        //     score = 0;
        // }
        scoreTxt.text = score.ToString();
    }

    void DisplayStars()
    {
        if(score >= pnt1 && score < pnt2)
        {
            Debug.Log("star 1");
            // hearts[i].enabled = true;
            star1.gameObject.SetActive(true);
        }
        else if(score >= pnt2 && score < pnt3)
        {
            Debug.Log("star 1 and 2");
            // star1.enabled = true;
            // star2.enabled = true;
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            // hearts[i].enabled = true;
        }
        else if(score >= pnt3)
        {
            Debug.Log("star 1,2,3");
            // star1.enabled = true;
            // star2.enabled = true;
            // star3.enabled = true;
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
            // hearts[i].enabled = true;
        }
        else
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            // hearts[i].enabled = false;
        }
        
    }

    public void ChangeScene(int _sceneindex)
    {
        SceneManager.LoadScene(_sceneindex);
        Time.timeScale = 1f;
        // Debug.Log("changescr working");
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
        {
            // factScreenShown = true;
            // Debug.Log("Game end is true");
            factScreen.SetActive(true);
            Time.timeScale = 0f;
            if(score < scoreToPass)
            {
                // levelMenuScript.lvl2.SetActive(false);
                GameManager.instance.level3Unlocked = false;
                nxtLvlBtn.SetActive(false);
                scoreNeededLine.SetActive(true);
            }
            else
            {
                // levelMenuScript.lvl2.SetActive(true);
                GameManager.instance.level3Unlocked = true;
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
        // highScoreTxt.text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
        Time.timeScale = 1f;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
    }
    void Update()
    {
        if(gameEnd == true)
        {
            FactScreenLvl1();    
        }
    }
}
