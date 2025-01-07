using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float CurrentScore = 0;
    public float DeliveredPizzas = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStats(float score, float pizzas)
    {
        CurrentScore = score;
        DeliveredPizzas = pizzas;
    }
}
