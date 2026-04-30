using UnityEngine;

public class GameEndScript : MonoBehaviour
{


    public int GEndscore=0;

    public lvl1Buttons lvlManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvlManager=GameObject.FindGameObjectWithTag("LevelManager").GetComponent<lvl1Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GEndscore == 11)
        {
            lvlManager.gameEnd = true;
            // Debug.Log("Game Finish");
        }
    }
}
