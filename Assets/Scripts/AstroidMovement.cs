using UnityEngine;

public class AstroidMovement : MonoBehaviour
{

    float speed;
    public float acceleration = 1f;
    float position;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        speed = acceleration * Time.deltaTime;
        position = speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x, transform.position.y + position);

        Debug.Log(speed);
    }
}
