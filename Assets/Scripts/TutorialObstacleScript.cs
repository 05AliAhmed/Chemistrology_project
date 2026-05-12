using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class TutorialObstacleScript : MonoBehaviour
{
    public SpriteRenderer rendpenal;
    public SpriteRenderer penalhit;
    public BoxCollider2D myCollider;
    public BoxCollider2D PenaltyCollider;
    public float cooldown = 0.5f;
    public float destroycooldown = 3f;

    public bool penaltyhit;


    /* private Animator myAnim;
     private SpriteRenderer rend2;/

     /*  public BallScript ball;
       public PointScript points;*/

    /* public Text Score;
     int PlayerScore=0;
     public int point = 100;*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {

        rendpenal = GetComponent<SpriteRenderer>();
        penalhit.enabled = false;

        // myAnim=gameObject.GetComponentInChildren<Animator>();
        /* rend2=gameObject.GetComponentInChildren<SpriteRenderer>();
         rend2.enabled = true;*/

        /*ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        points = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();*/
        PenaltyCollider.enabled = false;
        penaltyhit = false;



    }
    private void FixedUpdate()
    {

    }


    // Update is called once per frame
    public void obstaclePenalty()
    {
     
        myCollider.enabled = false;
        PenaltyCollider.enabled = true;
        rendpenal.enabled = false;
        penalhit.enabled = true;
        //destroycooldown = 5f;
        if (cooldown > 0f)// this is for the victory effect- Chris
        {

            cooldown -= Time.deltaTime;



        }
        if (cooldown <= 0f)
        {
            Destroy(gameObject);

        }

    }
    /* void OnCollisionEnter2D(Collision2D collisioninfo)
     {
         if (collisioninfo.collider.tag == "Penalty")
         {
             Debug.Log("ggggggggg");

         }

     }*/
    void Update()
    {

       
    }
}
