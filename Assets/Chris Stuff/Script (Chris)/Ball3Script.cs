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
   // public TargetScriptTwo targethit;
    public NonozoneScript nonozone;
    public PointScript point;

    public bool targethit;
    
    int currentlvlindex;
    public lvl1Buttons levelmanager; // ref to lvl 1 script

    void Start()
    {
        currentlvlindex = SceneManager.GetActiveScene().buildIndex;
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
        levelmanager = GameObject.Find("LevelManager").GetComponent<lvl1Buttons>();
        nonozone = GameObject.FindGameObjectWithTag("Nonozone").GetComponent<NonozoneScript>();
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
            if(groupOfTargets.Contains(collisioninfo.gameObject))
            {
                //Debug.Log("it is found");
                collisioninfo.gameObject.GetComponent<TargetScript>().changeTarget(); // chnaging sprite
                //targethit = true;
                levelmanager.ScoreSystem(); // using scoresystem from levelbutton script
                levelmanager.ComboSystem(); // everytime targets been hit targetcount will increase by 1 if more than 2 awards comboscore - Ali Ahmed
            }

            
        }

        else if (collisioninfo.collider.tag == "Nonozone")
        {

            levelmanager.LoseScore(); // using losesystem from levelbutton script
            levelmanager.targetCount = 0; // if ball goes into nono zone sets target count to 0 hence no more combo - Ali Ahmed
            Destroy(gameObject);

        }
    }


}
