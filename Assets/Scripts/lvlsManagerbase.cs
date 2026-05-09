using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class lvlsManagerbase : MonoBehaviour
{
    // [Header("Score Settings")]
    [SerializeField] protected int amendScore;
    [SerializeField] protected int loseScore;
    [SerializeField] protected int comboScore;
    public int score;
    public int targetCount;

    public virtual void ScoreSystem(){
        score += amendScore;
        Debug.Log(score);
    }
    public virtual void ComboSystem(){
        targetCount++;
        if (targetCount > 2)
        {
            score += comboScore;
        }
        Debug.Log(score);
    }
    public virtual void LoseScore(){
        score -= loseScore;
        if(score < 0)
        {
            score = 0;
        }
        Debug.Log(score);
    }
}
