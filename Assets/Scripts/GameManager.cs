using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool level2Unlocked = false; //set true in level 1 script if conditions meet
    public bool level3Unlocked = false; //set true in level 2 script if conditions meet
    public bool level4Unlocked = false; //set true in level 3 script if conditions meet
    public bool level5Unlocked = false; //set true in level 4 script if conditions meet
    public bool level6Unlocked = false; //set true in level 5 script if conditions meet
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}