using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public int number;
    public float Timer=8f;
    public bool check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
     
        spawner1.SetActive(false);
        spawner2.SetActive(false);
        spawner3.SetActive(false);
    }
    public void randnum()
    {
        number = Random.Range(0, 6);
    }
    // Update is called once per frame
    void Update()
    {
        if (Timer > 0f)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0f)
        {
            Timer = 8f;
            randnum();
           if (number <= 1)
            {
                spawner1.SetActive(true);
               // spawner1.SetActive(check);

            }
           else if (number == 2 || number == 3)
            {
                spawner2.SetActive(true);
              // spawner2.SetActive(check);
            }
           else if (number >= 4)
            {
                spawner3.SetActive(true);
                //spawner3.SetActive(check);
                //system and script need some connection
            }

        }
       


    }
}
