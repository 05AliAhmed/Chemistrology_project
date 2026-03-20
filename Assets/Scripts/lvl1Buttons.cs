using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class lvl1Buttons : MonoBehaviour
{
    [SerializeField] int amendScore = 10;
    int score;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text highScoreTxt;

    public void ScoreSystem()
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
    public void BackOption()
    {
        SceneManager.LoadScene(0);
    }
    void Start()
    {
        highScoreTxt.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        
    }
}
