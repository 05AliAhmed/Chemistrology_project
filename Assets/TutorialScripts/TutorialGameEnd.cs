using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGameEnd : MonoBehaviour
{
    public int GEndscore = 0; // keeping count of targets hit, when sprite changes
    int currentlvlIndex;
    public GameObject phase1;
    
    void Start()
    {
    

    }
    void Update()
    {
    
                if (GEndscore == 2)
                {
            phase1.SetActive(false);
                }
              
        
    }
}