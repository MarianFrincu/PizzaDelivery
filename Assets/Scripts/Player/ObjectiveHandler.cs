using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            ObjectiveRelocator relocator = other.transform.parent.GetComponent<ObjectiveRelocator>();

            PlayerStats stats = GetComponent<PlayerStats>();

            float addedScore = Mathf.Clamp(relocator.GetRemainingTime() * 1.5f + stats.GetCurrentHealth() * 3f, 0, 50);

            stats.UpdateScore(addedScore);
            stats.AddOneDeliveredPizza();

            relocator.NextDelivery();
            stats.ResetHealth();

            if (!relocator.AreUndeliveredPizzas())
            {
                EndGame();
                return;
            }

        }
    }

    private void EndGame()
    {
        DifficultyManager difficultyManager = FindAnyObjectByType<DifficultyManager>();
        if (difficultyManager != null)
        {
            HighScoreManager highScoreManager = FindAnyObjectByType<HighScoreManager>();
            if (highScoreManager != null)
            {
                PlayerStats stats = GetComponent<PlayerStats>();
                highScoreManager.UpdateHighScore(difficultyManager.SelectedDifficulty, Mathf.RoundToInt(stats.GetCurrentScore()));
            }
        }
    }
}
