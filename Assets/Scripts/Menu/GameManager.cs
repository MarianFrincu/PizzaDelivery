using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float CurrentScore = 0;
    public float DeliveredPizzas = 0;

    private void Awake()
    {
        // Asigură-te că există un singur GameManager și nu este distrus între scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Nu distruge GameManager între scene
        }
        else
        {
            Destroy(gameObject); // Distruge instanțele duplicate
        }
    }

    // Metodă pentru a seta scorul și numărul de pizza livrate
    public void SetStats(float score, float pizzas)
    {
        CurrentScore = score;
        DeliveredPizzas = pizzas;
    }
}
