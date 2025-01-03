using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private const float _maxHealth = 100;

    private float _currentScore;
    private float _currentHealth;
    private float _deliveredPizzas;

    [SerializeField] private TMP_Text statsText;

    // variabila pt label
    // tot asa pt orice iti trebe pe UI

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
            statsText.text = $"<b>Score:</b> {_currentScore}\n<b>Health:</b> {_currentHealth}\n<b>Delivered Pizzas:</b> {_deliveredPizzas}";
        }
        else
        {
            Debug.LogWarning("statsText nu este asignat în Inspector!");
        }
    }

    void Update()
    {

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

    public void UpdateHealth(float damage)
    {
        _currentHealth -= damage;
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
}