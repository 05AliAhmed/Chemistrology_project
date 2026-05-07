using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float angleRad;
    public float angleDeg;
    public float degree;
    public float speed=25;
   public void angleCalculator()
    {
        angleRad= Mathf.Atan2(transform.position.y,transform.position.x);
        angleDeg = angleRad * Mathf.Rad2Deg;
        degree =   angleDeg-90;
       // Debug.Log(angleDeg);
      //  Debug.Log(degree);
       // Vector3 direction=(transform.position- new Vector3(0,0,0)).normalized;
       // Debug.Log(direction);
    }
    void Awake()
    {
        angleCalculator();
    }
    void Start()
    {
       
        Instantiate(obstacle, new Vector3(transform.position.x,transform.position.y, 0), Quaternion.Euler(0, 0,degree));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
    }
}
