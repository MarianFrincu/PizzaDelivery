using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _DifficultyMenu;
    [SerializeField] private GameObject _HighScorePanel;

    public void ShowDifficultyMenu()
    {
        _MainMenu.SetActive(false);
        _DifficultyMenu.SetActive(true);
    }
    public void ShowHighScorePanel()
    {
        _MainMenu.SetActive(false);
        _HighScorePanel.SetActive(true);
    }
    public void BackToMainMenu()
    {
        _MainMenu.SetActive(true);
        _DifficultyMenu.SetActive(false);
        _HighScorePanel.SetActive(false);
    }

    public void BackToMainMenuFromGame()
    {
        SceneManager.LoadScene("Menu");
    }


    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

}

