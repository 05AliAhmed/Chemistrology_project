using UnityEngine;

public class SoundsManagement : MonoBehaviour
{

    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource thisAudioSource;

    public AudioClip scoreSound;
    public AudioClip boomSound;
    //public AudioClip Sound;


    void Awqke()
    {
        thisAudioSource = GetComponent<AudioSource>();

        Debug.Log("the awaken audioSource = " + thisAudioSource);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisAudioSource = GetComponent<AudioSource>();

        Debug.Log("the awaken audioSource = " + thisAudioSource);

    }

    public void theScoreSound()
    {
        //Debug.Log("audioSource enabled = " + thisAudioSource.enabled);
        //Debug.Log("gameobject is = " + thisAudioSource.gameObject.name);

        if (!thisAudioSource.gameObject.activeInHierarchy)
        {
            thisAudioSource.gameObject.SetActive(true);
        }

        thisAudioSource.PlayOneShot(scoreSound);
    }
    public void vineBoomSound()
    {
        //Debug.LogWarning(boomSound);

        thisAudioSource.PlayOneShot(boomSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (thisAudioSource == null)
        {
            thisAudioSource = GetComponent<AudioSource>();
        }

        if (!thisAudioSource.gameObject.activeInHierarchy)
        {
            thisAudioSource.gameObject.SetActive(true);
        }
    }

}
