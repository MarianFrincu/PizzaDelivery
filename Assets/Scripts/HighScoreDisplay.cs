using TMPro; 
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text easyScoreText;
    [SerializeField] private TMP_Text mediumScoreText;
    [SerializeField] private TMP_Text hardScoreText;

    public void ShowHighScores()
    {
        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();

        if (highScoreManager != null)
        {
            Debug.Log($"Easy: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Easy)}, Medium: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Medium)}, Hard: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Hard)}");

            easyScoreText.text = $"Easy: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Easy)}";
            mediumScoreText.text = $"Medium: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Medium)}";
            hardScoreText.text = $"Hard: {highScoreManager.GetHighScore(DifficultyManager.Difficulty.Hard)}";
        }
        else
        {
            Debug.LogError("HighScoreManager nu a fost găsit!");
        }
    }

}
