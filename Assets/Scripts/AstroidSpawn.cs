using UnityEngine;

public class AstroidSpawn : MonoBehaviour
{

    public GameObject astroid;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 9f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(astroid, whereToSpawn,Quaternion.identity);
        }
    }
}
