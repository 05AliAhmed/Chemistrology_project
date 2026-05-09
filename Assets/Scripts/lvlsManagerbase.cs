using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class lvlsManagerbase : MonoBehaviour
{
    // [Header("Score Settings")]
    [SerializeField] protected int amendScore;
    [SerializeField] protected int loseScore;
    [SerializeField] protected int comboScore;
    public TMP_Text starScore1;
    public TMP_Text starScore2;
    public TMP_Text starScore3;
    public Image star1;
    public Image star2;
    public Image star3;
    public int pnt1;
    public int pnt2;
    public int pnt3;
    public int score;
    public int targetCount;

    public virtual void ScoreSystem(){
        score += amendScore;
        // Debug.Log(score);
    }
    public virtual void ComboSystem(){
        targetCount++;
        if (targetCount > 2)
        {
            score += comboScore;
        }
        // Debug.Log(score);
    }
    public virtual void LoseScore(){
        score -= loseScore;
        if(score < 0)
        {
            score = 0;
        }
        // Debug.Log(score);
    }

    public virtual void DisplayStars()
    {
        if(score >= pnt1 && score < pnt2)
        {
            star1.gameObject.SetActive(true);
        }
        else if(score >= pnt2 && score < pnt3)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            // hearts[i].enabled = true;
        }
        else if(score >= pnt3)
        {
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
        }
        
    }

    public virtual void Start()
    {
        starScore1.text = pnt1.ToString();
        starScore2.text = pnt2.ToString();
        starScore3.text = pnt3.ToString();
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
    }
}
