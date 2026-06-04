using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class lvl6 : lvlsManagerbase
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine; // progressbar
    [SerializeField] GameObject nxtLvlBtn; // ref to next lvl button if score > score needed yo pass the lvl.
    [SerializeField] float scoreToPass; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl 
    // [SerializeField] TMP_Text passScoreTxt; // txt ref for score needed to pass the lvl shown while playing 
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    [SerializeField] Camera cam;
    [SerializeField] GameObject vignette;
    [SerializeField] GameObject preview;
    public float cooldown = 3.2f;
    // Scene currentScene;
    public bool gameEnd;
    float passScore;

    public bool pauseInputs;

    public List<GameObject> groupOfTargets;
    public bool transitionScreenTriggered;
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
        if(score > PlayerPrefs.GetInt("Highscore6",0)) // if score is greater than H.S, 0 is there because at start high score is 0.
        {
            PlayerPrefs.SetInt("Highscore6", score); // setting Highscore to be the score continously 
            highScoreTxt.text = score.ToString();            
        }
    }
    public override void LoseScore()
    {
        base.LoseScore();
        scoreTxt.text = score.ToString();
    }

    public void ChangeScene(int _sceneindex)
    {
        GameManager.instance.GMLoadScene(_sceneindex);
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

    public void DisplayCard(){
        if(cooldown < 0f && !cardDisplayedonce)
        {
            if(score > pnt1)
            {
                GameManager.instance.levelPassed6 = true;
                StartCoroutine(CollectiblePopUP());    
            }       
        }
    }
    public void FactScreenLvl1()
    {
        if (!transitionScreenTriggered)
        {
            transitionScreenTriggered = true;
            TransitionLoadScreen.instance.PlayTransition();
        }

        //TransitionLoadScreen.instance.PlayTransition();
        // factScreen.SetActive(true);

        // GameManager.instance.pauseInputs = true;

        if (cooldown > 0f)// this is for the victory effect- Chris
        {
            vignette.SetActive(true);
            cooldown -= Time.deltaTime;
           // cam.orthographicSize -= Time.deltaTime;
            Time.timeScale = 0.5f;

        }
        if (cooldown < 0f)
        {
            //cam.orthographicSize = 5f;
            vignette.SetActive(false);
            factScreen.SetActive(true);
            GameManager.instance.pauseInputs = true;

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

    public override void Start()
    {
        base.Start();
        pausemenu.SetActive(false);
        factScreen.SetActive(false);
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore6", 0).ToString();
        Time.timeScale = 1f;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
        cooldown = 3.2f;
    }
    void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Preview disabled");
            preview.SetActive(false);
            GameManager.instance.pauseInputs = false;
        }
    }

    void Update()
    {
        ClickCheck();
        if(gameEnd == true)
        {
            FactScreenLvl1();    
        }
         // can use if statement to check scn and display its fact0scr

    }
}
