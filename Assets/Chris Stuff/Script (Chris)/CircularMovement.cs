using UnityEngine;
using UnityEngine.SceneManagement;

public class CircularMovement : MonoBehaviour
{
    int currentscnIndx;
    public float speed;

    public float increaseSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentscnIndx = SceneManager.GetActiveScene().buildIndex;
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
        if (!GameManager.instance.pauseInputs && currentscnIndx == 3)
        {
            gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, increaseSpeed * Time.deltaTime);    
            // Debug.Log("IT IS WORKING ELECTRONS CAN SPEED UP");
        }
        if (!GameManager.instance.pauseInputs && currentscnIndx == 7)
        {
            gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, increaseSpeed * Time.deltaTime); 
            // Debug.Log("IT IS WORKING ELECTRONS CAN SPEED UP 6");   
        }
        //gameObject.transform.Rotate(0f,0f,10f*Time.deltaTime);
        
    }
}
