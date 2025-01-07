using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void GoToMenu()
    {
        Debug.Log("Navigare către meniul principal.");
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Jocul s-a închis!");
        Application.Quit();
    }
}
