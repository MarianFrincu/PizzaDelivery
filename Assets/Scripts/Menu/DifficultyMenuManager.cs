using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenuManager : MonoBehaviour
{

    public void SetEasyDifficulty()
    {
        DifficultyManager.Instance.SelectedDifficulty = DifficultyManager.Difficulty.Easy;
        LoadGameScene();
    }

    public void SetMediumDifficulty()
    {
        DifficultyManager.Instance.SelectedDifficulty = DifficultyManager.Difficulty.Medium;
        LoadGameScene();
    }

    public void SetHardDifficulty()
    {
        DifficultyManager.Instance.SelectedDifficulty = DifficultyManager.Difficulty.Hard;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
