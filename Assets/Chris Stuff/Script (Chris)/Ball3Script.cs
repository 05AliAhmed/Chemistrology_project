//using UnityEngine;

//public class Ball3Script : MonoBehaviour
//{


//    public Rigidbody2D rb;

//    public TargetScript target;
//    public NonozoneScript nonozone;
//    public PointScript point;
//    void Start()
//    {

//        target = GameObject.FindGameObjectWithTag("Target").GetComponent<TargetScript>();
//        nonozone = GameObject.FindGameObjectWithTag("Nonozone").GetComponent<NonozoneScript>();
//        point = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();
//    }
//    // Start is called once before the first execution of Update after the MonoBehaviour is created


//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKey(KeyCode.A))
//        {
//            rb.linearVelocity = Vector2.up * 5;
//        }


//    }
//    void OnCollisionEnter2D(Collision2D collisioninfo)
//    {
//        if (collisioninfo.collider.tag == "Target")
//        {

//            Destroy(gameObject);
//            target.changeTarget();
//            point.EarnPoint();
//            Debug.Log("GG");
//        }
//        if (collisioninfo.collider.tag == "Nonozone")
//        {

//            Destroy(gameObject);
//            point.LosePoint();

//        }
//    }
//}
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball3Script : MonoBehaviour
{
    [SerializeField] int comboScore;

    public Rigidbody2D rb;
    //[SerializeField] GameObject righttarget;
    public List<GameObject> groupOfTargets;
    public List<GameObject> groupOfObstacles;
    // public TargetScriptTwo targethit;
    public NonozoneScript nonozone;
    public PointScript point;
    public ObstacleScript obstacle;
    public bool targethit;

    // int currentlvlindex;
    lvlsManagerbase levelManager; // ref to lvl script
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
        levelManager = GameObject.Find("LevelManager").GetComponent<lvlsManagerbase>();

    }

    void Update()
    {/*
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * 100;
        }
        */

    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Target")
        {
            //Debug.Log("hit target");
            if (groupOfTargets.Contains(collisioninfo.gameObject))
            {
                //Debug.Log("it is found");
                collisioninfo.gameObject.GetComponent<TargetScript>().changeTarget(); // chnaging sprite
                Debug.Log(levelManager.GetType().Name);
                //targethit = true;
                // switch (currentlvlindex)
                // {
                //     case 3:
                // lvl1Buttons.ScoreSystem(); // using scoresystem from levelbutton script
                // lvl1Buttons.ComboSystem(); // everytime targets been hit targetcount will increase by 1 if more than 2 awards comboscore - Ali Ahmed

                // break;
                //     case 4:
                //         lvl2.ScoreSystem();
                //         lvl2.ComboSystem();
                //         break;

                //     default:
                //         break;
                // }
                levelManager.ScoreSystem();
                levelManager.ComboSystem();
                Destroy(gameObject);
                //bulletPool.Return(this);

            }


        }

        else if (collisioninfo.collider.tag == "Nonozone")
        {
            // switch (currentlvlindex)
            // {
            //     case 3:
            //         Debug.Log("Lvel one is here");
            // lvl1Buttons.LoseScore();
            // lvl1Buttons.targetCount = 0;
            //     break;
            // case 4:
            //     Debug.Log("Lvel two was here");
            //     lvl2.LoseScore();
            //     lvl2.targetCount = 0;
            //         break;

            //     default:
            //         break;
            // }

            levelManager.LoseScore(); // using losesystem from levelbutton script
            // levelManager.targetCount = 0; // if ball goes into nono zone sets target count to 0 hence no more combo - Ali Ahmed

            Destroy(gameObject);

        }
        if (collisioninfo.collider.tag == "Obstacle")
        {
            //Debug.Log("hit target");
            if (groupOfObstacles.Contains(collisioninfo.gameObject))
            {
               
                collisioninfo.gameObject.GetComponent<ObstacleScript>().penaltyhit=true; // chnaging sprite

                Debug.Log("obstacle hit");
                Destroy(gameObject);
            }


        }
    }



}