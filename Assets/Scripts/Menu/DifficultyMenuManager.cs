using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenuManager : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    public void SetEasyDifficulty()
    {
        difficultyManager.SelectedDifficulty = DifficultyManager.Difficulty.Easy;
        LoadGameScene();
    }

    public void SetMediumDifficulty()
    {
        difficultyManager.SelectedDifficulty = DifficultyManager.Difficulty.Medium;
        LoadGameScene();
    }

    public void SetHardDifficulty()
    {
        difficultyManager.SelectedDifficulty = DifficultyManager.Difficulty.Hard;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
