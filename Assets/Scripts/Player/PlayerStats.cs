using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private const int _maxHealth = 100;

    private float _currentScore;
    private int _currentHealth;
    private float _deliveredPizzas;
    private float _remainingTime;

    [SerializeField] private TMP_Text statsText;

    void Start()
    {
        _currentScore = 0;
        _currentHealth = _maxHealth;
        _deliveredPizzas = 0;
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
}
