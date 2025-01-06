using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }

    public Difficulty SelectedDifficulty = Difficulty.Medium;
    public float baseDeliveryTime = 60f;

    private static DifficultyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Păstrează acest obiect între scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetDeliveryTime()
    {
        switch (SelectedDifficulty)
        {
            case Difficulty.Easy:
                return baseDeliveryTime; // 100%
            case Difficulty.Medium:
                return baseDeliveryTime * 0.8f; // 80%
            case Difficulty.Hard:
                return baseDeliveryTime * 0.6f; // 60%
            default:
                return baseDeliveryTime;
        }
    }

    public void AssignObjectiveRelocator()
    {
        ObjectiveRelocator relocator = FindObjectOfType<ObjectiveRelocator>();
        if (relocator != null)
        {
            relocator.deliveryTime = GetDeliveryTime();
            Debug.Log("ObjectiveRelocator found and deliveryTime set: " + relocator.deliveryTime);
        }
        else
        {
            Debug.LogError("ObjectiveRelocator not found in the current scene!");
        }
    }
}
