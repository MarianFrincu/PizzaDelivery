using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text deliveredPizzasText;

    void Start()
    {
        scoreText.text = "Score: " + GameManager.Instance.CurrentScore;
        deliveredPizzasText.text = "Deliveres Pizzas: " + GameManager.Instance.DeliveredPizzas + "/10";
    }
}
