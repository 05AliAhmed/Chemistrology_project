using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class TransitionLoadScreen : MonoBehaviour
{
    [SerializeField] private float _fadeInDuration = 0.5f;
    [SerializeField] private float _fadeOutDuration = 0.5f;
    [SerializeField] private CanvasGroup _canvasGroup;

    private VideoPlayer _videoPlayer;

    public static TransitionLoadScreen instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _videoPlayer = GetComponent<VideoPlayer>();

        _canvasGroup.alpha = 0f;
        _canvasGroup.transform.parent.gameObject.SetActive(false);
    }

    private void Start()
    {
        ClearRenderTexture();
        _canvasGroup.alpha = 0;
    }

    // Drop the prefab of GS_A_transitiontoWS into the level
    // Call this when you win. Ensure you only call it once
    // Could do something liek this to ensure only called once:

    // On the class:
    //  bool transitionScreenTriggered

    // At win area:
    
    //  if (!transitionScreenTriggered)
    //    {
    //    transitionScreenTriggered = true;
    //    }

    //      TransitionLoadScreen.instance.PlayTransition();
    [ContextMenu("Play Transition")]
    public void PlayTransition()
    {
        _canvasGroup.transform.parent.gameObject.SetActive(true);
        _canvasGroup.alpha = 0f;

        double duration = _videoPlayer.length;

        _videoPlayer.Play();

        _canvasGroup.DOFade(1f, _fadeInDuration);

        float fadeOutStartTime = Mathf.Max(
            0f,
            (float)duration - _fadeOutDuration
        );

        DOVirtual.DelayedCall(fadeOutStartTime, () =>
        {
            _canvasGroup
                .DOFade(0f, _fadeOutDuration)
                .OnComplete(() =>
                {
                    _canvasGroup.transform.parent.gameObject.SetActive(false);
                });
        });
    }

    private void ClearRenderTexture()
    {
        RenderTexture renderTexture = _videoPlayer.targetTexture;
        RenderTexture current = RenderTexture.active;
        RenderTexture.active = renderTexture;

        GL.Clear(true, true, Color.clear);

        RenderTexture.active = current;
    }
}