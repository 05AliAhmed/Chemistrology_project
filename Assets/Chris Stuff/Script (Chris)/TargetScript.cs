using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
public class TargetScript : MonoBehaviour
{
    private SpriteRenderer rend;
    public CircleCollider2D myCollider;
    public CircleCollider2D penaltydetect;
    public Animator childanime;
    public bool filled;
    public ShootableElectronScript bulletScript;
    public GameEndScript GameEnd;
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        GameEnd=GameObject.FindGameObjectWithTag("GameEnd").GetComponent<GameEndScript>();
        penaltydetect.enabled = false;
       
    }


    public void changeTarget()
    {
        GameEnd.GEndscore += 1;
        myCollider.enabled = false;
        penaltydetect.enabled = true;
        childanime.SetBool("Triggered", true);
        filled = true;
    }

    void OnTriggerEnter2D(Collider2D  collisioninfo)
    {
        if (collisioninfo.tag == "Penalty" && filled==true)
        {
            GameEnd.GEndscore = GameEnd.GEndscore - 1;
            myCollider.enabled = true;
            penaltydetect.enabled = false;
            childanime.SetBool("Triggered", false);
            filled = false;
        }


    }

}
