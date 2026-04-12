using UnityEngine;

public class ShootableElectronScript : MonoBehaviour
{
    public float speed = 5;
    public float halfScreenHeight = 6;
    public float halfScreenWidth = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * Time.deltaTime * speed);

        //check the position of a bullet/electron across both X and Y co-ordinates; Z (depth) isn't necessary;
        if (transform.position.x < -halfScreenWidth || transform.position.x > halfScreenWidth)
        {
            //detroy the bullet/electron for optimisation purposes :)
            Destroy(gameObject);

        }
        if (transform.position.y < -halfScreenHeight || transform.position.y > halfScreenHeight)
        {
            //detroy the bullet/electron for optimisation purposes :)
            //Debug "";
            Destroy(gameObject);

        }

    }
}
