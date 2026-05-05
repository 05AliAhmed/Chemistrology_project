using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class lvlsManagerbase : MonoBehaviour
{
    // [Header("Score Settings")]
    [SerializeField] protected int amendScore;
    [SerializeField] protected int loseScore;
    [SerializeField] protected int comboScore;
    // [SerializeField] protected int scoreToPass;

    // [Header("Score UI")]
    // [SerializeField] protected TMP_Text scoreTxt;
    // // [SerializeField] protected TMP_Text passScoreTxt;
    // [SerializeField] protected TMP_Text highScoreTxt;

    public int score;
    public int targetCount;

    // protected string highScoreKey;

    // protected virtual void Start()
    // {
    //     int lvlIndex = SceneManager.GetActiveScene().buildIndex;
    //     highScoreKey = "Highscore" + lvlIndex;

    //     highScoreTxt.text = PlayerPrefs.GetInt(highScoreKey, 0).ToString();
    // }

    public virtual void ScoreSystem()
    {
        score += amendScore;
        Debug.Log(score);
        // scoreTxt.text = score.ToString();

        // int passScore = scoreToPass - score;
        // if (passScore < 0) passScore = 0;

        // // passScoreTxt.text = passScore.ToString();

        // // per-level highscore
        // if (score > PlayerPrefs.GetInt(highScoreKey, 0))
        // {
        //     PlayerPrefs.SetInt(highScoreKey, score);
        //     highScoreTxt.text = score.ToString();
        // }
    }

    public virtual void ComboSystem()
    {
        targetCount++;
        if (targetCount > 2)
        {
            score += comboScore;
            // scoreTxt.text = score.ToString();
        }
        Debug.Log(score);
    }

    public virtual void LoseScore()
    {
        score -= loseScore;
        if(score < 0)
        {
            score = 0;
        }
        Debug.Log(score);
        // if (score < 0) score = 0;

        // scoreTxt.text = score.ToString();
        // targetCount = 0;
    }

    // public int targetCount;

    // public virtual void ScoreSystem() { }
    // public virtual void ComboSystem()
    // {
    //     targetCount++;
    //     if(targetCount > 2) // checking if target hit are grater than 2
    //     {
    //         score += comboScore;  // then score plus comboscore
    //         // scoreTxt.text = score.ToString();
    //         // Debug.Log(score); // testing
    //     }
    // }
    // public virtual void LoseScore() { }
}
