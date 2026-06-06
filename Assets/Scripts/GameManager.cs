using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool levelPassed1 = false; // bool to display cards in card menu if requirements are met
    public bool level2Unlocked = false; //set true in level 1 script if conditions meet
    public bool levelPassed2 = false; // bool to display cards in card menu if requirements are met
    public bool level3Unlocked = false; //set true in level 2 script if conditions meet
    public bool levelPassed3 = false; // bool to display cards in card menu if requirements are met
    public bool level4Unlocked = false; //set true in level 3 script if conditions meet
    public bool levelPassed4 = false;// bool to display cards in card menu if requirements are met
    public bool level5Unlocked = false; //set true in level 4 script if conditions meet
    public bool levelPassed5 = false; // bool to display cards in card menu if requirements are met
    public bool level6Unlocked = false; //set true in level 5 script if conditions meet
    public bool levelPassed6 = false; // bool to display cards in card menu if requirements are met
    public bool pauseInputs = false;
 
    // public bool cardUnlocked = false;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator LoadScene(int _sceneindex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(9);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(_sceneindex);
    }

    public void GMLoadScene(int _sceneindex)
    {
        StartCoroutine(LoadScene(_sceneindex));
    }
}