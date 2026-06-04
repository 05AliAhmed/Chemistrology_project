using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidShowAndHide : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    public TargetScript targetScript;

    [SerializeField] private float hiddenDuration = 2.0f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void hideMe()
    {
        StartCoroutine(HideRoutine());
    }

    IEnumerator HideRoutine()
    {
        while (targetScript.filled != true)
        {
            
            yield return new WaitForSeconds(hiddenDuration * 1.5f);

            if (targetScript.filled != true)
            {
                //spriteRenderer.enabled = false;
                // col.enabled = false;
                StartCoroutine(FadeOut());
            }

            yield return new WaitForSeconds(hiddenDuration);

            /*
            if (targetScript.filled != true)
            {
                // spriteRenderer.enabled = true;
                //col.enabled = true;
                StartCoroutine(FadeIN());
            }
            */

            StartCoroutine(FadeIN());

            //yield return new WaitForSeconds(hiddenDuration);

            hideMe();

        } 
        
    }
    IEnumerator FadeOut()
    {
        float duration = 0.5f; // fade time
        float time = 0;

        Color startColor = spriteRenderer.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / duration);

            spriteRenderer.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );

            time += Time.deltaTime;
            yield return null;
        }

        // fully invisible
        spriteRenderer.color = new Color(
            startColor.r,
            startColor.g,
            startColor.b,
            0f
        );
        col.enabled = false;

    }
    IEnumerator FadeIN()
    {
        float duration = 0.5f; 
        float time = 0;

        Color startColor = spriteRenderer.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / duration);

            spriteRenderer.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );

            time += Time.deltaTime;
            yield return null;
        }

        // fully invisible
        spriteRenderer.color = new Color(
            startColor.r,
            startColor.g,
            startColor.b,
            1f
        );

        if (targetScript.filled != true)
        {
            col.enabled = true;
        }
        



    }
    void Start()
    {
        hideMe();

        /*
        if (targetScript.filled != true) 
        {
            hideMe();
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //make me visible again if you hit me while I fade out
        if ()
        {

            if (targetScript.filled != false)
            {

            }

        }
        */
    }
}
