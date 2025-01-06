using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private static HighScoreManager instance;

    public int easyHighScore;
    public int mediumHighScore;
    public int hardHighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighScores()
    {
        PlayerPrefs.SetInt("EasyHighScore", easyHighScore);
        PlayerPrefs.SetInt("MediumHighScore", mediumHighScore);
        PlayerPrefs.SetInt("HardHighScore", hardHighScore);
        PlayerPrefs.Save();
    }

    public void LoadHighScores()
    {
        easyHighScore = PlayerPrefs.GetInt("EasyHighScore", 0);  
        mediumHighScore = PlayerPrefs.GetInt("MediumHighScore", 0);
        hardHighScore = PlayerPrefs.GetInt("HardHighScore", 0);
        Debug.Log($"High Scores Loaded: Easy: {easyHighScore}, Medium: {mediumHighScore}, Hard: {hardHighScore}");
    }


    public void UpdateHighScore(DifficultyManager.Difficulty difficulty, int score)
    {
        switch (difficulty)
        {
            case DifficultyManager.Difficulty.Easy:
                if (score > easyHighScore)
                {
                    easyHighScore = score;
                    SaveHighScores();
                }
                break;
            case DifficultyManager.Difficulty.Medium:
                if (score > mediumHighScore)
                {
                    mediumHighScore = score;
                    SaveHighScores();
                }
                break;
            case DifficultyManager.Difficulty.Hard:
                if (score > hardHighScore)
                {
                    hardHighScore = score;
                    SaveHighScores();
                }
                break;
        }
    }

    public int GetHighScore(DifficultyManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case DifficultyManager.Difficulty.Easy:
                return easyHighScore;
            case DifficultyManager.Difficulty.Medium:
                return mediumHighScore;
            case DifficultyManager.Difficulty.Hard:
                return hardHighScore;
            default:
                return 0;
        }
    }
}
