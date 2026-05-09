// using Microsoft.Unity.VisualStudio.Editor;
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
        HS2.text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
        HS3.text = PlayerPrefs.GetInt("Highscore3", 0).ToString();
        HS4.text = PlayerPrefs.GetInt("Highscore4", 0).ToString();
        HS5.text = PlayerPrefs.GetInt("Highscore5", 0).ToString();
        HS6.text = PlayerPrefs.GetInt("Highscore6", 0).ToString();

    }
}
