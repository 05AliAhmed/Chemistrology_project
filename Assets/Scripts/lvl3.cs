using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvl3 : lvlsManagerbase
{ 
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine; // progressbar
    [SerializeField] GameObject nxtLvlBtn; // ref to next lvl button if score > score needed yo pass the lvl.
    [SerializeField] float scoreToPass; // testing purpose if score 500 proceed to level 2 if less display a msg 
                                        // after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl 
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    // Scene currentScene;
    public bool gameEnd;
    float passScore;
    public bool pauseInputs;

    public List<GameObject> groupOfTargets;

    public override void ComboSystem() // awarding combo points
    {
        base.ComboSystem();
        scoreTxt.text = score.ToString();
    }
    public override void ScoreSystem() // will late be connected with shooting system to count scores | Score Button
    {
        base.ScoreSystem();
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
    public override void LoseScore()
    {
        base.LoseScore();
        scoreTxt.text = score.ToString();
    }
    // void DisplayStars()
    // {
    //     if(score >= pnt1 && score < pnt2)
    //     {
    //         Debug.Log("star 1");
    //         star1.gameObject.SetActive(true);
    //     }
    //     else if(score >= pnt2 && score < pnt3)
    //     {
    //         star1.gameObject.SetActive(true);
    //         star2.gameObject.SetActive(true);
    //     }
    //     else if(score >= pnt3)
    //     {
    //         star1.gameObject.SetActive(true);
    //         star2.gameObject.SetActive(true);
    //         star3.gameObject.SetActive(true);
    //     }
    //     else
    //     {
    //         star1.enabled = false;
    //         star2.enabled = false;
    //         star3.enabled = false;
    //     }
        
    // }

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

    // public void DisplayCard(){
    //     if(cooldown < 0f && !cardDisplayedonce)
    //     {
    //         if(score > pnt1)
    //         {
    //             StartCoroutine(CollectiblePopUP());    
    //         }       
    //     }
    // }
    public void FactScreenLvl1()
    {
        factScreen.SetActive(true);
        Time.timeScale = 0f;
        if(score < scoreToPass)
        {
            GameManager.instance.level4Unlocked = false;
            nxtLvlBtn.SetActive(false);
            scoreNeededLine.SetActive(true);
        }
        else
        {
            GameManager.instance.level4Unlocked = true;
            nxtLvlBtn.SetActive(true);
            scoreNeededLine.SetActive(false);
        }
        DisplayStars();        
    }

    public override void Start()
    {
        base.Start();
        pausemenu.SetActive(false);
        factScreen.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore3", 0).ToString();
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
