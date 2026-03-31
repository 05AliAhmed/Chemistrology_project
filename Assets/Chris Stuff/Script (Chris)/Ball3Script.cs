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
using UnityEngine;

public class Ball3Script : MonoBehaviour
{

    public Rigidbody2D rb;
    //[SerializeField] GameObject righttarget;
    public List<GameObject> groupOfTargets;
   // public TargetScriptTwo targethit;
    public NonozoneScript nonozone;
    public PointScript point;
    void Start()
    {
        groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
            //.GetComponent<TargetScript>();
      //  targethit = GameObject.FindGameObjectWithTag("Targets").GetComponent<TargetScriptTwo>();
        nonozone = GameObject.FindGameObjectWithTag("Nonozone").GetComponent<NonozoneScript>();
        point = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * 100;
        }


    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Target")
        {

            Destroy(gameObject);
            
            if(groupOfTargets.Contains(collisioninfo.gameObject))
            {
                collisioninfo.gameObject.GetComponent<TargetScript>().changeTarget();
            }
            point.EarnPoint();
            Debug.Log("GG");

        }
        /*if (collisioninfo.collider.tag == "Targets")
        {

            Destroy(gameObject);
            targethit.changeTarget();
            point.EarnPoint();
            Debug.Log("GG");
        }*/
        if (collisioninfo.collider.tag == "Nonozone")
        {

            Destroy(gameObject);
            point.LosePoint();

        }
    }
}
