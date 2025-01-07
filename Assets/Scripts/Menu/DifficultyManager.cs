using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }

    public Difficulty SelectedDifficulty;
    public int baseDeliveryTime = 60;

    public static DifficultyManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetDeliveryTime()
    {
        switch (Instance.SelectedDifficulty)
        {
            case Difficulty.Easy:
                return baseDeliveryTime; // 100%
            case Difficulty.Medium:
                return Mathf.RoundToInt(baseDeliveryTime * 0.8f); // 80%
            case Difficulty.Hard:
                return Mathf.RoundToInt(baseDeliveryTime * 0.6f); // 60%
            default:
                return baseDeliveryTime;
        }
    }
}
