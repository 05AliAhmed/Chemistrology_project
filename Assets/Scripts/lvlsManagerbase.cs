using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class lvlsManagerbase : MonoBehaviour
{
    // [Header("Score Settings")]
    [SerializeField] protected int amendScore;
    [SerializeField] protected int loseScore;
    [SerializeField] protected int comboScore;
    public TMP_Text starScore1;
    public TMP_Text starScore2;
    public TMP_Text starScore3;
    public TMP_Text comboCountText;
    public Image star1;
    public Image star2;
    public Image star3;
    public GameObject collectible; 
    [SerializeField] Animator cardAnimator;
    public int pnt1;
    public int pnt2;
    public int pnt3;
    public int score;
    public int targetCount;
    public int comboCount;
    public float cardDisplayTimer;
    public bool cardDisplayedonce;

    // public SpeedBonusCalculator speedBonusScript;


    public virtual void ScoreSystem(){
        score += amendScore;

        // score += speedBonusScript.SpeedBonus;
        // speedBonusScript.SpeedBonus = 50;
        // speedBonusScript.calculateSpeed();

        // Debug.Log(score);
    }
    public virtual void ComboSystem(){
        targetCount++;
        if (targetCount > 2)
        {
            score += comboScore;
            comboCount++;
            comboCountText.text = comboCount.ToString() + "x HITS\n +20points";
        }
        // Debug.Log(score);
    }
    public virtual void LoseScore(){
        score -= loseScore;
        targetCount = 0;
        comboCount = 0;
        comboCountText.text = " "; //+ comboCount.ToString();        
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
            // collectible.SetActive(true);
            // StartCoroutine(CollectiblePopUP());
            // collectible.SetActive(true);
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

    public IEnumerator CollectiblePopUP()
    {
        // Debug.Log("couroutine is working");
        collectible.SetActive(true);
        cardAnimator.SetBool("winScr",true);
        yield return new WaitForSeconds(cardDisplayTimer);
        // Debug.Log("timer is working");
        cardAnimator.SetBool("winScr", false);
        cardDisplayedonce = true;
        // collectible.SetActive(false);
    }

    public virtual void Start()
    {
        GameManager.instance.pauseInputs = false;
        starScore1.text = pnt1.ToString();
        starScore2.text = pnt2.ToString();
        // Debug.Log("workingngngngngngng");
        starScore3.text = pnt3.ToString();
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        collectible.SetActive(false);
        // Debug.Log("set it to false");
        cardDisplayedonce = false;
    }
}
