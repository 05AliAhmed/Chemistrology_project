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
                spriteRenderer.enabled = false;
                col.enabled = false;
            }

            yield return new WaitForSeconds(hiddenDuration);

            if (targetScript.filled != true)
            {
                spriteRenderer.enabled = true;
                col.enabled = true;
            }

            //yield return new WaitForSeconds(hiddenDuration);

            hideMe();

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
        
    }
}
