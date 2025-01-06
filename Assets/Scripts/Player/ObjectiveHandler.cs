using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    private int _score;
    [SerializeField] private CollisionHandler collisionHandler;

    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        if (collisionHandler.IsCompletelyDamaged())
        {
            Debug.Log("Comanda este complet distrusă și nu poate fi livrată!");
            // Adaugă logica pentru anularea livrării
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {

            other.transform.parent.GetComponent<ObjectiveRelocator>().MoveToNextPosition();

            _score += 10;

            Debug.Log(_score);
        }
    }

    private void EndGame()
    {
        DifficultyManager difficultyManager = FindObjectOfType<DifficultyManager>();
        if (difficultyManager != null)
        {
            HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
            if (highScoreManager != null)
            {
                highScoreManager.UpdateHighScore(difficultyManager.SelectedDifficulty, _score);
            }
        }
    }
}
