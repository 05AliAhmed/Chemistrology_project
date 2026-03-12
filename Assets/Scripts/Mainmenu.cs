using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour

{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
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

