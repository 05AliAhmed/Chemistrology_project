using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;



public class lvl1Buttons : lvlsManagerbase
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine; // progressbar
    [SerializeField] GameObject nxtLvlBtn; 
    [SerializeField] GameObject vignette; // ref to next lvl button if score > score needed yo pass the lvl.
    [SerializeField] float scoreToPass; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl  
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    [SerializeField] Camera cam;
    public bool gameEnd;
    float passScore;
    public float cooldown=2f;
    // public bool pauseInputs;
    public List<GameObject> groupOfTargets;
    
    public override void ComboSystem() // awarding combo points
    {
        base.ComboSystem();
        // Debug.Log("lvl 1 combosytem called");
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
        // Debug.Log("score system");
        // score += amendScore;
        base.ScoreSystem();
        // Debug.Log("lvl 1 scoresytem called");
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
        if(score > PlayerPrefs.GetInt("Highscore",0)) // if score is greater than H.S, 0 is there because at start high score is 0.
        {
            PlayerPrefs.SetInt("Highscore", score); // setting Highscore to be the score continously 
            highScoreTxt.text = score.ToString();
            // passScoreTxt.text = passScore.ToString();            
        }
    }
    public override void LoseScore()
    {
        base.LoseScore();
        // Debug.Log("lvl 1 losescore called");
        // score -= loseScore;
        scoreTxt.text = score.ToString();
    }

    public void ChangeScene(int _sceneindex)
    {
        //DontDestroyOnLoad(gameObject);
        //StartCoroutine(LoadScene( _sceneindex));
        SceneManager.LoadScene(_sceneindex);
        Time.timeScale = 1f;
        // Debug.Log("changescr working");
    }

    public void PauseButton() // is used for pasusing the game | Settings button
    {
        // pauseInputs = true;
        GameManager.instance.pauseInputs = true;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton() // for resuming the game
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        // pauseInputs = false;
        GameManager.instance.pauseInputs = false;
    }
    public void DisplayCard(){
        if(cooldown < 0f && !cardDisplayedonce)
        {
            if(score > pnt1)
            {
                StartCoroutine(CollectiblePopUP());    
            }       
        }
    }

    public void FactScreenLvl1()
    {
        if (gameEnd == true)
        {
            if (cooldown > 0f)// this is for the victory effect- Chris
            {
                vignette.SetActive(true);
                cooldown -= Time.deltaTime;
                cam.orthographicSize -= Time.deltaTime;
                Time.timeScale = 0.5f;

            }
            if (cooldown < 0f)
            {
                cam.orthographicSize = 5f;
                vignette.SetActive(false);
                factScreen.SetActive(true);
                // if(score > pnt1){
                //     // collectible.SetActive(true);
                //     // cardAnimator.SetBool("winscr", true);   
                //     // StartCoroutine(CollectiblePopUP()); 
                // }

                GameManager.instance.pauseInputs = true;
                // Time.timeScale = 0f;
            }

            if (score < scoreToPass)
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
            DisplayCard();
        }
    }

    /*IEnumerator LoadScene(int _sceneindex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(9);
      

        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene(_sceneindex);
        Time.timeScale = 1f;
    }*/
    public override void Start()
    {
        base.Start();
        pausemenu.SetActive(false);
        factScreen.SetActive(false);
        vignette.gameObject.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        Time.timeScale = 1f;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
        cooldown = 2f;
        // cardAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(gameEnd == true)
        {
            FactScreenLvl1();   
        }
        
    }
}
