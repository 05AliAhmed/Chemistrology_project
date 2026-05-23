using UnityEngine;

public class popupeffect : MonoBehaviour
{
    float cooldown = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f)// this is for the victory effect- Chris
        {

            cooldown -= Time.deltaTime;



        }
        if (cooldown <= 0f)
        {
            Destroy(gameObject);

        }
    }
}
