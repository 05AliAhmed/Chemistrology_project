using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GameManager.instance.pauseInputs = false;
        //Debug.Log("rotating");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.instance.pauseInputs)
        {
            gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);    
        }
        //gameObject.transform.Rotate(0f,0f,10f*Time.deltaTime);
        
    }
}
