using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LMenu : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;
    public GameObject lvl5;
    public GameObject lvl6;

   // [SerializeField] Animator transitionAnim;
    public void LevelOne() // takes to level 1
    {
        //transitionAnim.SetTrigger("End");
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        //transitionAnim.SetTrigger()
    }

    public void LevelTwo() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void LevelThree() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void LevelFour() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(5);
    }
    public void LevelFive() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(6);
    }
    public void LevelSix() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(7);
    }

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

    }

  
    void Update()
    {
        
    }
}
