using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public const int _maxHealth = 100;

    private float _currentScore;
    private int _currentHealth;
    private float _deliveredPizzas;
    private float _remainingTime;

    [SerializeField] private TMP_Text statsText;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;

    void Start()
    {
        _currentScore = 0;
        _currentHealth = _maxHealth;
        _deliveredPizzas = 0;
        audioSource = GetComponent<AudioSource>();
        UpdateStatsUI();
    }

    void UpdateStatsUI()
    {
        if (statsText != null)
        {
            string seconds = _remainingTime < 10 ? $"0{_remainingTime}" : _remainingTime.ToString();
            statsText.text = $"<b>Score:</b> {_currentScore}\n<b>Health:</b> {_currentHealth}\n<b>Delivered Pizzas:</b> {_deliveredPizzas}\n<b>Remaining Time:</b> {seconds}";
        }
        else
        {
            Debug.LogWarning("statsText nu este asignat în Inspector!");
        }
    }

    public float GetCurrentScore()
    {
        return _currentScore;
    }

    public void UpdateScore(float addedScore)
    {
        _currentScore += addedScore;
        UpdateStatsUI();
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void UpdateHealth(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        UpdateStatsUI();

        if (_currentHealth <= 0)
        {
            TriggerExplosionAndRestart();
        }
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        UpdateStatsUI();
    }

    public float GetDeliveredPizzas()
    {
        return _deliveredPizzas;
    }

    public void AddOneDeliveredPizza()
    {
        _deliveredPizzas += 1;
        UpdateStatsUI();
    }

    public float GetRemainingTime()
    {
        return _remainingTime;
    }

    public void UpdateRemainingTime(int remainingTime)
    {
        _remainingTime = remainingTime;
        UpdateStatsUI();
    }

    private void TriggerExplosionAndRestart()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        Camera mainCamera = GetComponentInChildren<Camera>();
        if (mainCamera != null)
        {
            Vector3 newCameraPosition = mainCamera.transform.position - mainCamera.transform.forward * 10;
            mainCamera.transform.position = newCameraPosition;
        }

        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        foreach (var collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }

        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Invoke(nameof(RestartGame), 2f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}