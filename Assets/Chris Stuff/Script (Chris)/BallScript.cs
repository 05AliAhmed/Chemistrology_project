using UnityEngine;

public class BallScript : MonoBehaviour
{
   
       public Rigidbody2D rb;

    public TargetScript target;
    public NonozoneScript nonozone;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<TargetScript>();
        nonozone= GameObject.FindGameObjectWithTag("Nonozone").GetComponent<NonozoneScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * 100;
        }

        
    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Target")
        {

            Destroy(gameObject);
            target.changeTarget();
            Debug.Log("GG");
        }
        if (collisioninfo.collider.tag == "Nonozone")
        {

            Destroy(gameObject);
            
        }
    }
}
