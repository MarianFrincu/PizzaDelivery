using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu; // Grupul care conține titlul și butoanele principale
    public GameObject difficultyMenu; // Grupul care conține butoanele pentru dificultate
    public GameObject highScorePanel;
    public void ShowDifficultyMenu()
    {
        // Ascunde meniul principal
        mainMenu.SetActive(false);
        // Afișează meniul de dificultate
        difficultyMenu.SetActive(true);
    }
    public void ShowHighScorePanel()
    {
        // Ascunde meniul principal
        mainMenu.SetActive(false);
        // Afișează meniul de dificultate
        highScorePanel.SetActive(true);
    }
    public void BackToMainMenu()
    {
        // Afișează meniul principal
        mainMenu.SetActive(true);
        // Ascunde meniul de dificultate
        difficultyMenu.SetActive(false);
    }
}
