using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    
    public AudioClip pauseClip;
    public AudioClip resumeClip;
    public AudioClip newGameClip;
    public AudioClip pieceMoveClip;
    public AudioClip pieceRotateClip;
    public AudioClip pieceDropClip;
    private AudioSource audioSource;

    public void PlayPauseClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(pauseClip);
        }
    }

    public void PlayResumeClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(resumeClip);
        }
    }

    public void PlayNewGameClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(newGameClip);
        }
    }

    public void PlayPieceMoveClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(pieceMoveClip);
        }
    }

    public void PlayPieceRotateClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(pieceRotateClip);
        }
    }

    public void PlayPieceDropClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(pieceDropClip);
        }
    }

    public void PlayToggleOnClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(resumeClip);
        }
    }

    public void PlayToggleOffClip()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource.PlayOneShot(pauseClip);
        }
    }

    internal void Awake()
    {
        if (gameObject.activeSelf == true)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}
