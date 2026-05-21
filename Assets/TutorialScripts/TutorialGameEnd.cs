using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TutorialGameEnd : MonoBehaviour
{
    public int GEndscore = 0; // keeping count of targets hit, when sprite changes
    int currentlvlIndex;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject combotxt;
    public GameObject phase5;
    public float cooldown =3f;
    public float cooldown2=3f;
    public bool explode = false;
    void Start()
    {
    phase2.SetActive(false);
    phase3.SetActive(false);
    phase4.SetActive(false);
    combotxt.SetActive(false);
        phase5.SetActive(false);
    }
    void Update()
    {
    
    if (GEndscore == 2)
     {
       //StartCoroutine(cooldown());
       phase1.SetActive(false);
            phase2.SetActive(true);
                }
    if (explode == true)
        {
          
            if (cooldown > 0f)
            {

                cooldown -= Time.deltaTime;


            }
            if (cooldown < 0f)
            {
            phase2.SetActive(false);
            phase3.SetActive(true);
               
                if (cooldown2 > 0f)// this is for the victory effect- Chris
                {

                    cooldown2 -= Time.deltaTime;


                }
                if (cooldown2 < 0f)
                {

                    phase3.SetActive(false);
                    phase4.SetActive(true);
                }
               
            }
            //cooldown = 3f;
        }
        if (GEndscore == 5)
        {
            combotxt.SetActive(true);
            if (cooldown > 0f)// this is for the victory effect- Chris
            {
                cooldown -= Time.deltaTime;
            }
            if (cooldown < 0f)
            {
            combotxt.SetActive (true);
                phase4.SetActive(false);
                phase5.SetActive(true);
            }
        }

    
    }


   
}