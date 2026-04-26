using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour

{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // to level 1
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(8);
    }

    public void QuitGame() // exit game
    {
        Application.Quit();
        Debug.Log("QUit is working");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

