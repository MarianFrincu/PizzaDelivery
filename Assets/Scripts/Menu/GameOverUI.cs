using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text deliveredPizzasText;

    void Start()
    {
        // Obține scorul și numărul de pizza livrate din GameManager
        scoreText.text = "Scor: " + GameManager.Instance.CurrentScore;
        deliveredPizzasText.text = "Pizza livrate: " + GameManager.Instance.DeliveredPizzas + "/10";
    }
}
