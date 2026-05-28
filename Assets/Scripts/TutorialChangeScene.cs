using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /* public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }*/
    public void ChangeScene(int _sceneindex)
    {
        GameManager.instance.GMLoadScene(_sceneindex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
