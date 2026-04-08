using UnityEngine;
using UnityEngine.SceneManagement;

public class LMenu : MonoBehaviour
{

    public void LevelOne() // takes to level 1
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
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
