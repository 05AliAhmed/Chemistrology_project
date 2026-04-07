using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicScript : MonoBehaviour
{

    public Rigidbody2D rb;
    //[SerializeField] GameObject righttarget;
    public List<GameObject> groupOfTargets;
    // public TargetScriptTwo targethit;
   
    public PointScript point;

    public bool targethit;

   


    // public lvl1Buttons lvl1Script;
    void Start()
    {
        

        //.GetComponent<TargetScript>();
        //  targethit = GameObject.FindGameObjectWithTag("Targets").GetComponent<TargetScriptTwo>();
        
        // point = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();
        // lvl1Script = FindAnyObjectByType<lvl1Buttons>();//GetComponent<lvl1Buttons>(); // reference to level1script which has score and lose system init - Ali Ahmed 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * 10;
        }


    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Target")
        {
            //Debug.Log("hit target");
            if (groupOfTargets.Contains(collisioninfo.gameObject))
            {
                //Debug.Log("it is found");
                collisioninfo.gameObject.GetComponent<TargetScript>().changeTarget();
                //targethit = true;
               // using scoresystem from levelbutton script
                Debug.Log(targethit);
            }
            // checking if target's been hit if yes true - Ali Ahmed
            // lvl1Script.ScoreSystem(); // accessing score system from lvl1script - Ali Ahmed
            // point.EarnPoint();
            Debug.Log("GG");
            Destroy(gameObject);

        }

        /*if (collisioninfo.collider.tag == "Targets")
        {

            Destroy(gameObject);
            targethit.changeTarget();
            point.EarnPoint();
            Debug.Log("GG");
        }*/
        else if (collisioninfo.collider.tag == "Nonozone")
        {

            

            // lvl1Script.LoseScore(); // accessing lose points system from lvl1script - Ali Ahmed
            Destroy(gameObject);
            // targethit = false; //checking if target's been hit if no false - Ali Ahmed
            // point.LosePoint();

        }
    }
}
