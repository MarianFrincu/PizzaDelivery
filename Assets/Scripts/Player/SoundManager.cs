using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource driveAudioSource;
    public AudioSource collisionAudioSource;

    [Header("Audio Clips")]
    public AudioClip driveSound;
    public AudioClip collisionSound;

    [Header("Vehicle Settings")]
    public Rigidbody vehicleRigidbody;

    private bool isDriving = false;

    void Start()
    {
        if (driveAudioSource && driveSound)
        {
            driveAudioSource.clip = driveSound;
            driveAudioSource.loop = true;
            driveAudioSource.volume = 0.1f;
            driveAudioSource.pitch = 1.0f;
            driveAudioSource.Play();
        }
    }

    void Update()
    {
        HandleDriveSound();
    }

    private void HandleDriveSound()
    {
        if (vehicleRigidbody)
        {
            float speed = vehicleRigidbody.linearVelocity.magnitude;
            bool isInputPressed = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

            if (speed > 0.1f || isInputPressed)
            {
                if (!isDriving)
                {
                    isDriving = true;
                }

                float targetVolume = Mathf.Clamp(speed / 10f, 0.1f, 1f);
                float targetPitch = Mathf.Clamp(speed / 10f + 1, 1f, 2f);

                driveAudioSource.volume = Mathf.Lerp(driveAudioSource.volume, targetVolume, Time.deltaTime * 2);
                driveAudioSource.pitch = Mathf.Lerp(driveAudioSource.pitch, targetPitch, Time.deltaTime * 2);
            }
            else
            {
                if (isDriving)
                {
                    isDriving = false;
                }
                driveAudioSource.volume = Mathf.Lerp(driveAudioSource.volume, 0, Time.deltaTime * 2);
            }
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
    }
}
