using UnityEngine;
using UnityEngine.SceneManagement;

public class CardCollectionsct : MonoBehaviour
{
    public GameObject cardBtn1;
    public GameObject cardBtn2;
    public GameObject cardBtn3;
    public GameObject cardBtn4;
    public GameObject cardBtn5;
    public GameObject cardBtn6;

    // GameObject _cards;

    public void DisplayCardCollection(GameObject _cards)
    {
        _cards.SetActive(true);
    }
    public void ChangeScene(int _sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneIndex);
    }
     
    void displayCollectedCards()
    {
        // switch (switch_on)
        // {
            
        //     default:
        // }

        if(GameManager.instance.levelPassed1 == true){
            Debug.Log("Card displayed");
            cardBtn1.SetActive(true);
        }
        if(GameManager.instance.levelPassed2 == true){
            Debug.Log("Card displayed level 2");
            cardBtn2.SetActive(true);
        }
        if(GameManager.instance.levelPassed3 == true){
            Debug.Log("Card displayed level 3");
            cardBtn3.SetActive(true);
        }
        if(GameManager.instance.levelPassed4 == true){
            Debug.Log("Card displayed level 4");
            cardBtn4.SetActive(true);
        }
        if(GameManager.instance.levelPassed5 == true){
            Debug.Log("Card displayed level 5");
            cardBtn5.SetActive(true);
        }
        if(GameManager.instance.levelPassed6 == true){
            Debug.Log("Card displayed level 6");
            cardBtn6.SetActive(true);
        }

    }

    void Awake()
    {
        cardBtn1.SetActive(false);
        cardBtn2.SetActive(false);
        cardBtn3.SetActive(false);
        cardBtn4.SetActive(false);
        cardBtn5.SetActive(false);
        cardBtn6.SetActive(false);
    }

    void Update()
    {
        displayCollectedCards();
    }
}
