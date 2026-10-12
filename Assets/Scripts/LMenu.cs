// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LMenu : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl12;
    public GameObject lvl13;
    
    [SerializeField] TMP_Text HS1;
    public GameObject lvl2;
    public GameObject lvl22;
    public GameObject lvl23;
    public GameObject Text2;

    [SerializeField] TMP_Text HS2;
    public GameObject lvl3;
    public GameObject lvl32;
    public GameObject lvl33;
    public GameObject Text3;

    [SerializeField] TMP_Text HS3;
    public GameObject lvl4;
    public GameObject lvl42;
    public GameObject lvl43;
    public GameObject Text4;

    [SerializeField] TMP_Text HS4;
    public GameObject lvl5;
    public GameObject lvl52;
    public GameObject lvl53;
    public GameObject Text5;

    [SerializeField] TMP_Text HS5;
    public GameObject lvl6;
    public GameObject lvl62;
    public GameObject lvl63;
    public GameObject Text6;


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

    public void ChangeScene(int _sceneindex)
    {
        GameManager.instance.GMLoadScene(_sceneindex);
    }
    void Start()
    {
        if (GameManager.instance.lvl1threestarunlock)
        {
            lvl13.SetActive(true);
            lvl1.SetActive(false);
        }
        else if (GameManager.instance.lvl1twostarunlock)
        {
            lvl12.SetActive(true);
            lvl1.SetActive(false);
        }
        if (GameManager.instance.level2Unlocked)
          
        {
            Text2.SetActive(true);
            if (GameManager.instance.lvl2threestarunlock)
            {
                lvl23.SetActive(true);
            }
            else if (GameManager.instance.lvl2twostarunlock)
            {
                lvl22.SetActive(true);
            }
            else 
            {
                lvl2.SetActive(true);
            }
         
        }
        if (GameManager.instance.level3Unlocked)
            
        {
            Text3.SetActive(true);
            if (GameManager.instance.lvl3threestarunlock)
            {
                lvl33.SetActive(true);
            }
            else if (GameManager.instance.lvl3twostarunlock)
            {
                lvl32.SetActive(true);
            }
            else 
            {
                lvl3.SetActive(true);
            }

        }
        if (GameManager.instance.level4Unlocked)
     
        {
            Text4.SetActive(true);
            if (GameManager.instance.lvl4threestarunlock)
            {
                lvl43.SetActive(true);
            }
            else if (GameManager.instance.lvl4twostarunlock)
            {
                lvl42.SetActive(true);
            }
            else 
            {
                lvl4.SetActive(true);
            }

        }
        if (GameManager.instance.level5Unlocked)

        {
            Text5.SetActive(true);

            if (GameManager.instance.lvl5threestarunlock)
            {
                lvl53.SetActive(true);
            }
            else if (GameManager.instance.lvl5twostarunlock)
            {
                lvl52.SetActive(true);
            }
            else 
            {
                lvl5.SetActive(true);
            }

        }
        if (GameManager.instance.level6Unlocked)
         
        {
            Text6.SetActive(true);
            if (GameManager.instance.lvl6threestarunlock)
            {
                lvl63.SetActive(true);
            }
            else if (GameManager.instance.lvl6twostarunlock)
            {
                lvl62.SetActive(true);
            }
            else 
            {
                lvl6.SetActive(true);
            }

        }
        if (!GameManager.instance.level2Unlocked)
        {
            lvl2.SetActive(false); // disabling the level 2 button
            lvl22.SetActive(false);
            lvl23.SetActive(false);
            Text2.SetActive(false);
        }
        if (!GameManager.instance.level3Unlocked)
        {
            lvl3.SetActive(false); // disabling the level 2 button
            lvl32.SetActive(false);
            lvl33.SetActive(false);
            Text3.SetActive(false);
        }
        if (!GameManager.instance.level4Unlocked)
        {
            lvl4.SetActive(false); // disabling the level 2 button
            lvl42.SetActive(false);
            lvl43.SetActive(false);
            Text4.SetActive(false);
        }
        if (!GameManager.instance.level5Unlocked)
        {
            lvl5.SetActive(false); // disabling the level 2 button
            lvl52.SetActive(false);
            lvl53.SetActive(false);
            Text5.SetActive(false);
        }
        if (!GameManager.instance.level6Unlocked)
        {
            lvl6.SetActive(false); // disabling the level 2 button
            lvl62.SetActive(false);
            lvl63.SetActive(false);
            Text6.SetActive(false);
        }

        HS1.text = PlayerPrefs.GetInt("Highscore",0).ToString();
        HS2.text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
        HS3.text = PlayerPrefs.GetInt("Highscore3", 0).ToString();
        HS4.text = PlayerPrefs.GetInt("Highscore4", 0).ToString();
        HS5.text = PlayerPrefs.GetInt("Highscore5", 0).ToString();
        HS6.text = PlayerPrefs.GetInt("Highscore6", 0).ToString();

    }
}
