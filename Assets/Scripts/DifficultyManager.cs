using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }

    public Difficulty SelectedDifficulty = Difficulty.Medium; // Dificultatea selectată
    public float baseDeliveryTime = 60f; // Timp de livrare de bază

    public float GetDeliveryTime()
    {
        switch (SelectedDifficulty)
        {
            case Difficulty.Easy:
                return baseDeliveryTime; // 100% timp
            case Difficulty.Medium:
                return baseDeliveryTime * 0.8f; // 80% timp
            case Difficulty.Hard:
                return baseDeliveryTime * 0.6f; // 60% timp
            default:
                return baseDeliveryTime;
        }
    }

}
