using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource driveAudioSource;
    public AudioSource collisionAudioSource;
    public AudioSource taskCompleteAudioSource;

    [Header("Audio Clips")]
    public AudioClip driveSound;
    public AudioClip collisionSound;
    public AudioClip taskCompleteSound;

    private bool isDriving = false;

    void Start()
    {
        PlayDriveSound();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!isDriving)
            {
                PlayDriveSound();
                isDriving = true;
            }
        }
        else
        {
            if (isDriving)
            {
                StopDriveSound();
                isDriving = false;
            }
        }
    }

    /*private void PlayObjectiveSound()
    {
        if (startAudioSource && startSound)
        {
            startAudioSource.clip = startSound;
            startAudioSource.Play();
        }
    }*/

    private void PlayDriveSound()
    {
        if (driveAudioSource && driveSound)
        {
            driveAudioSource.clip = driveSound;
            driveAudioSource.loop = true;
            driveAudioSource.Play();
        }
    }

    private void StopDriveSound()
    {
        if (driveAudioSource)
        {
            driveAudioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (collisionAudioSource && collisionSound)
            {
                collisionAudioSource.clip = collisionSound;
                collisionAudioSource.Play();
            }
        }
        if (collision.gameObject.CompareTag("Objective"))
        {
            if (taskCompleteAudioSource && taskCompleteSound)
            {
                taskCompleteAudioSource.clip = taskCompleteSound;
                taskCompleteAudioSource.Play();
                Debug.Log("Obiectiv atins! Sunetul de Task Complete a fost redat.");
            }
        }
    }
}
