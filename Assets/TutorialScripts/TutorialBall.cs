using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBall : MonoBehaviour
{
    [SerializeField] int comboScore;

    public Rigidbody2D rb;
    //[SerializeField] GameObject righttarget;
    public List<GameObject> groupOfTargets;
    public List<GameObject> groupOfObstacles;
    // public TargetScriptTwo targethit;
    public NonozoneScript nonozone;
    
    public TutorialObstacle obstacle;
    public bool targethit;

    // int currentlvlindex;
    //lvlsManagerbase levelManager; // ref to lvl script
    // lvl1Buttons lvl1Buttons;
    // lvl2 lvl2;

    void Start()
    {

        // currentlvlindex = SceneManager.GetActiveScene().buildIndex;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
        groupOfObstacles = GameObject.FindGameObjectsWithTag("Obstacle").ToList();
        // lvl1Buttons = GameObject.Find("LevelManager").GetComponent<lvl1Buttons>();
        // lvl2 = GameObject.Find("LevelManager").GetComponent<lvl2>();
        nonozone = GameObject.FindGameObjectWithTag("Nonozone").GetComponent<NonozoneScript>();
        //levelManager = GameObject.Find("LevelManager").GetComponent<lvlsManagerbase>();

    }

  
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "Target")
        {
            if (groupOfTargets.Contains(collisioninfo.gameObject))
            {
                Debug.Log("it is found");

                collisioninfo.GetComponent<TutorialTarget>().changeTarget();

                Destroy(gameObject);
            }
        }

        else if (collisioninfo.tag == "Nonozone")
        {
           
            Destroy(gameObject);
        }

        else if (collisioninfo.tag == "Obstacle")
        {
            if (groupOfObstacles.Contains(collisioninfo.gameObject))
            {
                collisioninfo.GetComponent<TutorialObstacle>().penaltyhit = true;
                Debug.Log("obstacle hit");

                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Nonozone")
        {
     
            Destroy(gameObject);

        }
        if (collisioninfo.collider.tag == "Obstacle")
        {
        
            if (groupOfObstacles.Contains(collisioninfo.gameObject))
            {

                collisioninfo.gameObject.GetComponent<TutorialObstacle>().penaltyhit = true; // chnaging sprite

                Debug.Log("obstacle hit");
                Destroy(gameObject);
            }
        }
       

    }
}