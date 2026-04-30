using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LMenu : MonoBehaviour
{
    public GameObject lvl1;
    [SerializeField] TMP_Text HS1;
    public GameObject lvl2;
    [SerializeField] TMP_Text HS2;
    public GameObject lvl3;
    [SerializeField] TMP_Text HS3;
    public GameObject lvl4;
    [SerializeField] TMP_Text HS4;
    public GameObject lvl5;
    [SerializeField] TMP_Text HS5;
    public GameObject lvl6;
    [SerializeField] TMP_Text HS6;

    public void ChangeScn(int levelindx)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelindx);
    }

   // [SerializeField] Animator transitionAnim;
    // public void LevelOne() // takes to level 1
    // {
    //     //transitionAnim.SetTrigger("End");
       
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene(2);
    //     //transitionAnim.SetTrigger()
    // }

    // public void LevelTwo() // takes to level 1
    // {
    //     // Time.timeScale = 1f;
    //     SceneManager.LoadScene(3);
    // }
    // public void LevelThree() // takes to level 1
    // {
    //     // Time.timeScale = 1f;
    //     SceneManager.LoadScene(4);
    // }
    // public void LevelFour() // takes to level 1
    // {
    //     // Time.timeScale = 1f;
    //     SceneManager.LoadScene(5);
    // }
    // public void LevelFive() // takes to level 1
    // {
    //     // Time.timeScale = 1f;
    //     SceneManager.LoadScene(6);
    // }
    // public void LevelSix() // takes to level 1
    // {
    //     // Time.timeScale = 1f;
    //     SceneManager.LoadScene(7);
    // }

    public void backoption()
    {
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        if (!GameManager.instance.level2Unlocked)
        {
            lvl2.SetActive(false); // disabling the level 2 button
        }
        if (!GameManager.instance.level3Unlocked)
        {
            lvl3.SetActive(false); // disabling the level 2 button
        }
        if (!GameManager.instance.level4Unlocked)
        {
            lvl4.SetActive(false); // disabling the level 2 button
        }
        if (!GameManager.instance.level5Unlocked)
        {
            lvl5.SetActive(false); // disabling the level 2 button
        }
        if (!GameManager.instance.level6Unlocked)
        {
            lvl6.SetActive(false); // disabling the level 2 button
        }

        HS1.text = PlayerPrefs.GetInt("Highscore",0).ToString();

    }

  
    void Update()
    {
        
    }
}
