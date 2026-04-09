using UnityEngine;
using UnityEngine.UI;
public class TargetScript : MonoBehaviour
{
    private SpriteRenderer rend;
    public CircleCollider2D myCollider;
    public Animator childanime;

   /* private Animator myAnim;
    private SpriteRenderer rend2;/*
   
    


    /*  public BallScript ball;
      public PointScript points;*/

    /* public Text Score;
     int PlayerScore=0;
     public int point = 100;*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        // myAnim=gameObject.GetComponentInChildren<Animator>();
        /* rend2=gameObject.GetComponentInChildren<SpriteRenderer>();
         rend2.enabled = true;*/

        /*ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        points = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();*/
    }

    // Update is called once per frame
    public void changeTarget()
    {
        // rend.sprite = TargetHit;
        //Destroy(rend);
        myCollider.enabled = false;
        //childsr.enabled=true;
        Debug.Log($" {gameObject.name}called");
        childanime.Play("TargetTrans");
        //childanime.SetBool("isAttacked", true);
        /*PlayerScore = PlayerScore + point;
      
        Score.text = PlayerScore.ToString();*/
    }
    void Update()
    {
        
    }
}
