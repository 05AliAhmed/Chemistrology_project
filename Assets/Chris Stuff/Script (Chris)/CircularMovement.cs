using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Rotate(0f,0f,10f*Time.deltaTime);
        gameObject.transform.RotateAround(new Vector3(-0.1f, -0.4f, 0), Vector3.forward, 50f * Time.deltaTime);
    }
}
