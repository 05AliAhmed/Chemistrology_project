
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class lvl1Buttons : MonoBehaviour
{
    [SerializeField] GameObject pausemenu; // reference to pausemenu panel
    [SerializeField] GameObject factScreen; // reference to fact screen panel
    [SerializeField] GameObject scoreNeededLine;
    [SerializeField] GameObject nxtLvlBtn; // ref to next lvl button if score > score needed yo pass the lvl.
    [SerializeField] int amendScore = 10; // in inspector can change the value
    [SerializeField] int loseScore = 50; // in inspector can change the value
    // [SerializeField] int targetsHit; // mannualy hitting and checking checking if all targets been hit | Number of electron in atom
    // [SerializeField] int totalTarget; // number of electron is an atom per level
    [SerializeField] float scoreToPassLOne; // testing purpose if score 500 proceed to level 2 if less display a msg after all targets been hit
    [SerializeField] TMP_Text scoreTxt; // txt ref for score text in lvl 
    [SerializeField] TMP_Text passScoreTxt; // txt ref for score needed to pass the lvl shown while playing 
    [SerializeField] TMP_Text highScoreTxt; // txt ref for high score text in fact screen
    [SerializeField] TMP_Text factScrScoreTxt; // txt ref for score text in fact screen
    [SerializeField] TMP_Text factScrScoreNeededTxt; // txt ref for score needed text in fact screen
    // [SerializeField] Ball3Script electronScript; // reference
    public bool gameEnd;
    public Image progressBar;
    int score; // keeping the score variable.
    int highScore;
    float passScore;


    public void ScoreSystem() // will late be connected with shooting system to count scores | Score Button
    {
        Debug.Log("score system");
        score += amendScore;
        scoreTxt.text = score.ToString();
        factScrScoreTxt.text = score.ToString();
        passScore = scoreToPassLOne - score; 
        // highScore = score; // testing purpose not working remove highscore int and this line later.
        if(passScore < 0)
        {
            passScore = 0;
        }
        passScoreTxt.text = passScore.ToString();
        factScrScoreNeededTxt.text = passScore.ToString();
        if(score > PlayerPrefs.GetInt("Highscore",0)) // if score is greater than H.S, 0 is there because at start high score is 0.
        {
            PlayerPrefs.SetInt("Highscore", score); // setting Highscore to be the score continously 
            highScoreTxt.text = score.ToString();
            // passScoreTxt.text = passScore.ToString();            
        }
        Debug.Log(score); // testing
        Debug.Log("CONNECTED"); // testing
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
    public void Retry() // Retry level 1 
    {
        SceneManager.LoadScene(1);
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Proceedlvl2()
    {
        SceneManager.LoadScene(3);
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
    public void FactScreenLvl1()
    {
        if(gameEnd == true)
        {
            Debug.Log("Game end is true");
            factScreen.SetActive(true);
            Time.timeScale = 0f;
            if(score < scoreToPassLOne)
            {
                nxtLvlBtn.SetActive(false);
                scoreNeededLine.SetActive(true);
            }
            else
            {
                nxtLvlBtn.SetActive(true);
                scoreNeededLine.SetActive(false);
            }
        }        
    }
    void Start()
    {
        pausemenu.SetActive(false);
        factScreen.SetActive(false);
        Debug.Log(gameEnd);
        PlayerPrefs.SetInt("Highscore", 0); // setting highscore to zero everytime game starts or new level starts, I knwo high score is to be kept even when game has been quit for that make a new highscore variable for each level??
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        progressBar.fillAmount = 1;
        // electronScript = FindAnyObjectByType<Ball3Script>();
        //electronScript = GameObject.FindGameObjectsWithTag("Ball");
        // electronScript = GetComponent<Ball3Script>();
    }

    void Update()
    {
        FactScreenLvl1();
        progressBar.fillAmount = passScore / scoreToPassLOne;


        // if(electronScript.targethit)
        // {
        //     ScoreSystem();
        //     Debug.Log("Well Connected");
        // }
        // else
        // {
        //     LoseScore();
        // }

        // if(targetsHit == totalTarget) // For testing purpose
        // {
        //     //pop fact screen, display score, high score | In proper play
        //     // if(score < scoreToPassLOne)
        //     // {
        //     //     Debug.Log($"You need {scoreToPassLOne - score} more points to proceed");
        //     //     Debug.Log($"{score}");
        //     //     Debug.Log($"{highScore}");
        //     // }
        //     // else
        //     // {
        //     //     Debug.Log("Here is the fact");
        //     //     Debug.Log($"{score}");
        //     //     Debug.Log($"{highScore}");
        //         // display next button | next button.setactive(true);               
        //     }
        // }
        // // else
        // {
        //     // Debug.Log("Not yet");
        // }
    }
}
