using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidShowAndHide : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    public TargetScript targetBehaviour;

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

        if (targetBehaviour.filled != true)
        {

            spriteRenderer.enabled = false;
            col.enabled = false;

            yield return new WaitForSeconds(hiddenDuration);

            spriteRenderer.enabled = true;
            col.enabled = true;

            yield return new WaitForSeconds(hiddenDuration);

            hideMe();
        }

    }

    void Start()
    {
        hideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
