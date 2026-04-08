using UnityEngine;
using UnityEngine.SceneManagement;

public class LMenu : MonoBehaviour
{

    public void LevelOne() // takes to level 1
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(1);
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
        SceneManager.LoadScene(1);
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
