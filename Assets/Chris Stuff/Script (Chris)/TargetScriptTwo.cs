using UnityEngine;
using UnityEngine.UI;
public class TargetScriptTwo : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite TargetHit;
    /*  public BallScript ball;
      public PointScript points;*/

    /* public Text Score;
     int PlayerScore=0;
     public int point = 100;*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        /*ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        points = GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>();*/
    }

    // Update is called once per frame
    public void changeTarget()
    {
        rend.sprite = TargetHit;
        /*PlayerScore = PlayerScore + point;
      
        Score.text = PlayerScore.ToString();*/
    }
    void Update()
    {

    }
}