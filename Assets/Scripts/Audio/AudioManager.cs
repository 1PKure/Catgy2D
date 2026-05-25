using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip moveClip;
    [SerializeField] private AudioClip crashClip;
    [SerializeField] private AudioClip winClip;

    public void PlayMoveSound()
    {
        PlaySound(moveClip);
    }

    public void PlayCrashSound()
    {
        PlaySound(crashClip);
    }

    public void PlayWinSound()
    {
        PlaySound(winClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource == null || clip == null)
        {
            return;
        }

        audioSource.PlayOneShot(clip);
    }
}