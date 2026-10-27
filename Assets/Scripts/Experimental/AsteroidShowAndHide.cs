using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidShowAndHide : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    public TargetScript targetScript;

    [SerializeField] private float hiddenDuration = 2.0f;

    //two bool variables to control the loop of the coroutine.
    public bool isCouroutineActive = false;
    public bool doCoroutine = false;

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
        isCouroutineActive = true;

        yield return new WaitForSeconds(hiddenDuration * 1.5f);

        if (targetScript.filled != true)
        {
            //spriteRenderer.enabled = false;
            // col.enabled = false;
            StartCoroutine(FadeOut());
        }

        yield return new WaitForSeconds(hiddenDuration);

        StartCoroutine(FadeIN());

        yield return new WaitForSeconds(1);

        isCouroutineActive = false;

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
        //hideMe();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCouroutineActive != true)
        {
            hideMe();
        }
    }
}
