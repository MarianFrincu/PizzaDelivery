using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }

    public Difficulty SelectedDifficulty = Difficulty.Medium;
    public int baseDeliveryTime = 60;

    private static DifficultyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetDeliveryTime()
    {
        switch (SelectedDifficulty)
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
