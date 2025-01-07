using UnityEngine;

public class SuccesSound : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource taskCompleteAudioSource;

    [Header("Audio Clips")]
    public AudioClip taskCompleteSound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (taskCompleteAudioSource && taskCompleteSound)
            {
                taskCompleteAudioSource.clip = taskCompleteSound;
                taskCompleteAudioSource.Play();
            }
        }
    }

}
