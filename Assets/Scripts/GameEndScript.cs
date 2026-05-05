using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{


    public int GEndscore=0;
    int currentlvlIndex;

    public lvl1Buttons lvlManager;
    lvl2 lvl2Manager;
    lvl3 lvl3Manager;
    lvl4 lvl4Manager;
    lvl5 lvl5Manager;
    lvl6 lvl6Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlvlIndex = SceneManager.GetActiveScene().buildIndex;
        lvlManager=GameObject.FindGameObjectWithTag("LevelManager").GetComponent<lvl1Buttons>();
        lvl2Manager = GameObject.Find("LevelManager").GetComponent<lvl2>();
        lvl3Manager = GameObject.Find("LevelManager").GetComponent<lvl3>();
        lvl4Manager = GameObject.Find("LevelManager").GetComponent<lvl4>();
        lvl5Manager = GameObject.Find("LevelManager").GetComponent<lvl5>();
        lvl6Manager = GameObject.Find("LevelManager").GetComponent<lvl6>();
    }

    // Update is called once per frame
    void Update()
    {
        // can use switch case here
        switch (currentlvlIndex)
        {
            case 2:
                if (GEndscore == 11)
                {
                   lvlManager.gameEnd = true;
                }
                break;
            case 3:
                if (GEndscore == 10)
                {
                   lvl2Manager.gameEnd = true;
                }
                break;
            case 4:
                if (GEndscore == 9)
                {
                   lvl3Manager.gameEnd = true;
                }
                break;
            case 5:
                if (GEndscore == 8)
                {
                   lvl4Manager.gameEnd = true;
                }
                break;
            case 6:
                if (GEndscore == 7)
                {
                   lvl5Manager.gameEnd = true;
                }
                break;
            case 7:
                if (GEndscore == 6)
                {
                   lvl6Manager.gameEnd = true;
                }
                break;            
            default:
                break;
        }
        
        // if (GEndscore == 11)
        // {
        //     lvlManager.gameEnd = true;
        //     // Debug.Log("Game Finish");
        // }
        // else if(GEndscore == 10)
        // {
        //     lvl2Manager.gameEnd = true;
        // }
    }
}
