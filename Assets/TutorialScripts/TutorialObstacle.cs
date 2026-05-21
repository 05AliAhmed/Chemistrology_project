using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;
public class TutorialObstacle : MonoBehaviour
{
    public SpriteRenderer rendpenal;
    public SpriteRenderer penalhit;
    public GameObject explodeeffect;
    public BoxCollider2D myCollider;
    public BoxCollider2D PenaltyCollider;
    public float cooldown = 0.5f;
    public float destroycooldown = 3f;
    public int speed = 150;
    public bool penaltyhit;

    public TutorialGameEnd GameEnd;



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

        GameEnd = GameObject.FindGameObjectWithTag("GameEnd").GetComponent<TutorialGameEnd>();

    }
    private void FixedUpdate()
    {
        //gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
    }


    // Update is called once per frame
    public void obstaclePenalty()
    {
        speed = 0;
        myCollider.enabled = false;
        PenaltyCollider.enabled = true;
        Instantiate(explodeeffect, transform.position, Quaternion.identity);
        rendpenal.enabled = false;
        //GameEnd.explode = true;
        // penalhit.enabled = true;
        //destroycooldown = 5f;
        if (cooldown > 0f)// this is for the victory effect- Chris
        {

            cooldown -= Time.deltaTime;



        }
        if (cooldown <= 0f)
        {
            Destroy(gameObject);
            GameEnd.explode = true;
        }

    }


   
    void Update()
    {
        if (penaltyhit == true)
        {
            obstaclePenalty();
        }
    }
    

}
