using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class ObstacleSystem : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public int number;
    public float Timer=8f;
    public bool check;
    public List<GameObject> groupOfObspawner;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        groupOfObspawner = GameObject.FindGameObjectsWithTag("Obspawner").ToList();
        StartCoroutine(MyCoroutine());

    }
    public void randnum()
    {
        number = Random.Range(0, 6);
    }

    IEnumerator MyCoroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(8f);

            SpawnFunc();
        }
    }

    public void SpawnFunc()
    {
        {
            randnum();
            Timer = 8f;
            if (number <= 1)
            {
                 spawner1.GetComponent<ObstacleSpawner>().spawn();
               
                // spawner1.SetActive(check);

            }
            else if (number == 2 || number == 3)
            {
                 spawner2.GetComponent<ObstacleSpawner>().spawn();
                // spawner2.SetActive(check);
            }
            else if (number >= 4)
            {
                spawner3.GetComponent<ObstacleSpawner>().spawn();
                //spawner3.SetActive(check);
                //system and script need some connection
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        /* if (Timer > 0f)
         {
             Timer -= Time.deltaTime;
         }
         if (Timer <= 0f)
         {     
             randnum();
             Timer = 8f;
             if (number <= 1)
             {
                // spawner1.GetComponent<ObstacleSpawner>().spawn();
                 // spawner1.SetActive(check);

             }
            else if (number == 2 || number == 3)
             {
                // spawner2.GetComponent<ObstacleSpawner>().spawn();
                 // spawner2.SetActive(check);
             }
            else if (number >= 4)
             {
                 //spawner3.GetComponent<ObstacleSpawner>().spawn();
                 //spawner3.SetActive(check);
                 //system and script need some connection
             }

         }*/
       


    }
}
