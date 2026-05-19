using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool level2Unlocked = false; //set true in level 1 script if conditions meet
    public bool level3Unlocked = false; //set true in level 2 script if conditions meet
    public bool level4Unlocked = false; //set true in level 3 script if conditions meet
    public bool level5Unlocked = false; //set true in level 4 script if conditions meet
    public bool level6Unlocked = false; //set true in level 5 script if conditions meet
    public bool pauseInputs = false;
    

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
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(_sceneindex);
    }

    public void GMLoadScene(int _sceneindex)
    {
        StartCoroutine(LoadScene(_sceneindex));
    }
}