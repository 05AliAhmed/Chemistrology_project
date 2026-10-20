using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;
public class ObstacleScript : MonoBehaviour
{
    public SpriteRenderer rendpenal;
    public GameObject explodeeffect;
    public BoxCollider2D myCollider;
    public BoxCollider2D PenaltyCollider;
    public AudioSource explosion;
    public float cooldown = 0.5f;
    public float destroycooldown = 3f;
    public int speed = 150;
    public bool penaltyhit;
    void Start()
    {

        rendpenal = GetComponent<SpriteRenderer>();
        PenaltyCollider.enabled = false;
        penaltyhit = false;
        explosion.Stop();

    }
    private void FixedUpdate()
    {
        gameObject.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
    }


    // Update is called once per frame
    public void obstaclePenalty()
    {
        explosion.Play();
        speed = 0;
        myCollider.enabled = false;
        PenaltyCollider.enabled = true;
        Instantiate(explodeeffect,transform.position, Quaternion.identity);
        rendpenal.enabled = false;

        if (cooldown > 0f)// this is for the victory effect- Chris
        {
            cooldown -= Time.deltaTime;
            
        }
        if (cooldown <= 0f)
        {
            Destroy(gameObject);
        }
       
    }

   void Update()
    {

        if (destroycooldown > 0f&&penaltyhit==false)// this is for the victory effect- Chris
        {
            destroycooldown -= Time.deltaTime;
        }
        if (destroycooldown <= 0f && penaltyhit == false)
        {
            StartCoroutine(FadeSprite());

        }
        if (penaltyhit==true)
        {
            obstaclePenalty();
        }
    }
    IEnumerator FadeSprite()
    {
        float duration = 0.5f; // fade time
        float time = 0;

        Color startColor = rendpenal.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / duration);

            rendpenal.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );

            time += Time.deltaTime;
            yield return null;
        }

        // fully invisible
        rendpenal.color = new Color(
            startColor.r,
            startColor.g,
            startColor.b,
            0f
        );

        Destroy(gameObject); // optional
     
    }

}
