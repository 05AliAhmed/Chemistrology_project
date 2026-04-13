using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour

{
    public void PlayGame()
    {
        SceneManager.LoadScene(2); // to level 1
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

