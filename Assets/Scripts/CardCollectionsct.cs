// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardCollectionsct : MonoBehaviour
{
    [Header("Card Buttons")]
    public Image cardBtn1;
    public Image cardBtn2;
    public Image cardBtn3;
    public Image cardBtn4;
    public Image cardBtn5;
    public Image cardBtn6;

    [Header("New Card Sprites")]
    public Sprite newoneCard;
    public Sprite newtwoCard;
    public Sprite newthreeCard;
    public Sprite newfourCard;
    public Sprite newfiveCard;
    public Sprite newsixCard;

    [Header("Displayed Cards")]
    public GameObject cardOne;
    public GameObject cardTwo;
    public GameObject cardThree;
    public GameObject cardFour;
    public GameObject cardFive;
    public GameObject cardSix;


    // GameObject _cards;

    public void DisplayOneCardCollection()
    {
        if(GameManager.instance.levelPassed1 == true) cardOne.SetActive(true);
    }

    public void DisplayCardTwoCollection()
    {
        if(GameManager.instance.levelPassed2 == true) cardTwo.SetActive(true);
    }

    public void DisplayCardThreeCollection()
    {
        if(GameManager.instance.levelPassed3 == true) cardThree.SetActive(true);
    }

    public void DisplayCardFourCollection()
    {
        if(GameManager.instance.levelPassed4 == true) cardFour.SetActive(true);
    }

    public void DisplayCardFiveCollection()
    {
        if(GameManager.instance.levelPassed5 == true) cardFive.SetActive(true);
    }

    public void DisplayCardSixCollection()
    {
        if(GameManager.instance.levelPassed6 == true) cardSix.SetActive(true);
    }

    public void ChangeScene(int _sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneIndex);
    }

    public void CardMenuOne()
    {
        // SceneManager.LoadScene(10);
        cardOne.SetActive(false);
    }

    public void CardMenuTwo()
    {
        // Debug.Log("working fine as hell");
        // SceneManager.LoadScene(10);
        cardTwo.SetActive(false);
    }

    public void CardMenuThree()
    {
        // SceneManager.LoadScene(10);
        cardThree.SetActive(false);
    }
    public void CardMenuFour()
    {
        // SceneManager.LoadScene(10);
        cardFour.SetActive(false);
    }

    public void CardMenuFive()
    {
        // SceneManager.LoadScene(10);
        cardFive.SetActive(false);
    }

    public void CardMenuSix()
    {
        // SceneManager.LoadScene(10);
        cardSix.SetActive(false);
    }
        
    void displayCollectedCards()
    {

        if(GameManager.instance.levelPassed1 == true){
            Debug.Log("Card displayed");
            // cardBtn1.SetActive(true);
            cardBtn1.sprite = newoneCard;
        }
        if(GameManager.instance.levelPassed2 == true){
            Debug.Log("Card displayed level 2");
            // cardBtn2.SetActive(true);
            cardBtn2.sprite = newtwoCard;
        }
        if(GameManager.instance.levelPassed3 == true){
            Debug.Log("Card displayed level 3");
            // cardBtn3.SetActive(true);
            cardBtn3.sprite = newthreeCard;
        }
        if(GameManager.instance.levelPassed4 == true){
            Debug.Log("Card displayed level 4");
            // cardBtn4.SetActive(true);
            cardBtn4.sprite = newfourCard;
        }
        if(GameManager.instance.levelPassed5 == true){
            Debug.Log("Card displayed level 5");
            // cardBtn5.SetActive(true);
            cardBtn5.sprite = newfiveCard;
        }
        if(GameManager.instance.levelPassed6 == true){
            Debug.Log("Card displayed level 6");
            // cardBtn6.SetActive(true);
            cardBtn6.sprite = newsixCard;
        }

    }

    void Awake()
    {
        // cardBtn1.SetActive(false);
        // cardBtn2.SetActive(false);
        // cardBtn3.SetActive(false);
        // cardBtn4.SetActive(false);
        // cardBtn5.SetActive(false);
        // cardBtn6.SetActive(false);

        cardOne.SetActive(false);
        cardTwo.SetActive(false);
        cardThree.SetActive(false);
        cardFour.SetActive(false);
        cardFive.SetActive(false);
        cardSix.SetActive(false);

    }

    void Update()
    {
        displayCollectedCards();
    }
}
