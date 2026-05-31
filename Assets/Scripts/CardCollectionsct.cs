// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardCollectionsct : MonoBehaviour
{
    [Header("Locked Buttons")]
    public GameObject cardBtn1;
    public GameObject cardBtn2;
    public GameObject cardBtn3;
    public GameObject cardBtn4;
    public GameObject cardBtn5;
    public GameObject cardBtn6;

    [Header("New Card Materials")]
    public Material newoneCard;
    public Material newtwoCard;
    public Material newthreeCard;
    public Material newfourCard;
    public Material newfiveCard;
    public Material newsixCard;

    [Header("Unlocked Cards")]
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
            cardBtn1.SetActive(false);
            cardOne.SetActive(true);
            // cardBtn1.material = newoneCard;
        }
        if(GameManager.instance.levelPassed2 == true){
            Debug.Log("Card displayed level 2");
            cardBtn2.SetActive(false);
            cardTwo.SetActive(true);
            // cardBtn2.material = newtwoCard;
        }
        if(GameManager.instance.levelPassed3 == true){
            Debug.Log("Card displayed level 3");
            cardBtn3.SetActive(false);
            cardThree.SetActive(true);
            // cardBtn3.material = newthreeCard;
        }
        if(GameManager.instance.levelPassed4 == true){
            Debug.Log("Card displayed level 4");
            cardBtn4.SetActive(false);
            cardFour.SetActive(true);
            // cardBtn4.material = newfourCard;
        }
        if(GameManager.instance.levelPassed5 == true){
            Debug.Log("Card displayed level 5");
            cardBtn5.SetActive(false);
            cardFive.SetActive(true);
            // cardBtn5.material = newfiveCard;
        }
        if(GameManager.instance.levelPassed6 == true){
            Debug.Log("Card displayed level 6");
            cardBtn6.SetActive(false);
            cardSix.SetActive(true);
            // cardBtn6.material = newsixCard;
        }

    }

    void Awake()
    {
        cardBtn1.SetActive(true);
        cardBtn2.SetActive(true);
        cardBtn3.SetActive(true);
        cardBtn4.SetActive(true);
        cardBtn5.SetActive(true);
        cardBtn6.SetActive(true);

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
