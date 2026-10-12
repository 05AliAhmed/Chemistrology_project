using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour

{
    public void PlayGame(int _scnIndx)
    {
        SceneManager.LoadScene(_scnIndx); // to level 1
    }

    public void CardCollectionScreen(int _scnIndx)
    {
        SceneManager.LoadScene(_scnIndx); // to level 1
    }
    // public void Tutorial()
    // {
    //     SceneManager.LoadScene(8);
    // }

    public void QuitGame() // exit game
    {
        Application.Quit();
        Debug.Log("QUit is working");
    }
}

