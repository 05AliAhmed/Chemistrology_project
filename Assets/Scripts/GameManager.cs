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

    public bool lvl1onestarunlock = false;
    public bool lvl1twostarunlock = false;
    public bool lvl1threestarunlock = false;

    public bool lvl2onestarunlock = false;
    public bool lvl2twostarunlock = false;
    public bool lvl2threestarunlock = false;

    public bool lvl3onestarunlock = false;
    public bool lvl3twostarunlock = false;
    public bool lvl3threestarunlock = false;

    public bool lvl4onestarunlock = false;
    public  bool lvl4twostarunlock = false;
    public bool lvl4threestarunlock = false;

    public bool lvl5onestarunlock = false;
    public bool lvl5twostarunlock = false;
    public bool lvl5threestarunlock = false;

    public bool lvl6onestarunlock = false;
    public bool lvl6twostarunlock = false;
    public bool lvl6threestarunlock = false;
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