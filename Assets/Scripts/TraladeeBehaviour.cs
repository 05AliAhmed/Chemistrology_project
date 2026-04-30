using UnityEngine;

public class TraladeeBehaviour : MonoBehaviour
{
    public GameObject bullet; //this basically just allows the player object to access the bullet electron object
    public float cooldownDuration = 2; //this is how long it takes for the the player to be able to shoot again (it's in seconds, obviously).
    public float shootingTimer = 0; //this counts up to allow the player to shoot.

    lvl1Buttons levelManager;

    //IT BELONGS TO THE SHOOTING CODE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // levelManager = FindAnyObjectByType<lvl1Buttons>();
        // levelManager = GetComponent<lvl1Buttons>(); // ref to lvl1 script bool var to pause movement on pause and resume on resume
        // Debug.Log("I am here");
        // levelManager.pauseInputs = true;
       //GameManager.instance.pauseInputs = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (shootingTimer < cooldownDuration)
        {

            shootingTimer = shootingTimer + (1 * Time.deltaTime);
            //Time.deltaTime

        }

        if (Input.GetMouseButtonDown(0))
        {
            //if(GameManager.instance.pauseInputs == false)
            {
                //AIMING CODE
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

                transform.up = direction;

                //SHOOTING CODE
                //this creates the electron and rotates it in the player's position and rotation respectively.

                

                if (shootingTimer >= cooldownDuration)
                {

                    // Debug.Log("*spit!*");
                    Instantiate(bullet, transform.position, transform.rotation);
                    shootingTimer = 0;

                } else
                {
                    // Debug.Log("wait for it... ");
                }
            }

        }
        //test code to move the object; this was to see if bullets really spawned but just didn't move in early coding
        //transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }

}