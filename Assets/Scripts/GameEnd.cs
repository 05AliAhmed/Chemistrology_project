using UnityEngine;

public class GameEndScript : MonoBehaviour
{


    public int GEndscore=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GEndscore == 11)
        {
            Debug.Log("Game Finish");
        }
    }
}
