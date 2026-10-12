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

    public void DisplayOneCardCollection(){
        if(GameManager.instance.levelPassed1 == true) cardOne.SetActive(true);
    }
    public void DisplayCardTwoCollection(){
        if(GameManager.instance.levelPassed2 == true) cardTwo.SetActive(true);
    }
    public void DisplayCardThreeCollection(){
        if(GameManager.instance.levelPassed3 == true) cardThree.SetActive(true);
    }
    public void DisplayCardFourCollection(){
        if(GameManager.instance.levelPassed4 == true) cardFour.SetActive(true);
    }
    public void DisplayCardFiveCollection(){
        if(GameManager.instance.levelPassed5 == true) cardFive.SetActive(true);
    }
    public void DisplayCardSixCollection(){
        if(GameManager.instance.levelPassed6 == true) cardSix.SetActive(true);
    }

    public void ChangeScene(int _sceneIndex){
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneIndex);
    }

    public void CardMenuOne(){
        cardOne.SetActive(false);
    }
    public void CardMenuTwo(){
        cardTwo.SetActive(false);
    }
    public void CardMenuThree(){
        cardThree.SetActive(false);
    }
    public void CardMenuFour(){
        cardFour.SetActive(false);
    }
    public void CardMenuFive(){
        cardFive.SetActive(false);
    }
    public void CardMenuSix(){
        cardSix.SetActive(false);
    }
        
    void displayCollectedCards()
    {

        if(GameManager.instance.levelPassed1 == true){
            cardBtn1.SetActive(false);
            cardOne.SetActive(true);
        }
        if(GameManager.instance.levelPassed2 == true){
            cardBtn2.SetActive(false);
            cardTwo.SetActive(true);
        }
        if(GameManager.instance.levelPassed3 == true){
            cardBtn3.SetActive(false);
            cardThree.SetActive(true);
        }
        if(GameManager.instance.levelPassed4 == true){
            cardBtn4.SetActive(false);
            cardFour.SetActive(true);
        }
        if(GameManager.instance.levelPassed5 == true){
            cardBtn5.SetActive(false);
            cardFive.SetActive(true);
        }
        if(GameManager.instance.levelPassed6 == true){
            cardBtn6.SetActive(false);
            cardSix.SetActive(true);
        }

    }

    void Awake()
    {
        // locked cards
        cardBtn1.SetActive(true);
        cardBtn2.SetActive(true);
        cardBtn3.SetActive(true);
        cardBtn4.SetActive(true);
        cardBtn5.SetActive(true);
        cardBtn6.SetActive(true);
        // unlocked cards
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
