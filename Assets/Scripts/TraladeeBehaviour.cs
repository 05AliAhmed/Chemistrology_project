using UnityEngine;

public class TraladeeBehaviour : MonoBehaviour
{
    public GameObject bullet; //this basically just allows the player object to access the bullet electron object
    //IT BELONGS TO THE SHOOTING CODE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //AIMING CODE
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            transform.up = direction;

            //SHOOTING CODE
            //this creates the electron and rotates it in the player's position and rotation respectively
            Instantiate(bullet, transform.position, transform.rotation);

        }

        //test code to move the object; this was to see if bullets really spawned but just didn't move in early coding
        //transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
