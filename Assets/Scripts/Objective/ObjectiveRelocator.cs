using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjectiveRelocator : MonoBehaviour
{
    private List<Vector3> _positions;
    private int _deliveryTime = 0;
    private int _remainingTime = 0;

    private PlayerStats _stats;

    void Start()
    {
        DifficultyManager manager = FindAnyObjectByType<DifficultyManager>();
        if (manager != null)
        {
            _deliveryTime = manager.GetDeliveryTime();
        }
        else
        {
            Debug.LogError("DifficultyManager not found in GameScene!");
        }

        _positions = new List<Vector3>
        {
            new Vector3(24, 0, -12),
            new Vector3(46, 0, -33),
            new Vector3(1.5f, 0, -70),
            new Vector3(-2, 0, 96),
            new Vector3(42, 0, -110),
            new Vector3(41, 0, -160),
            new Vector3(41, 0, -180),
            new Vector3(41, 0, -200),
            new Vector3(41, 0, -220),
            new Vector3(-1.5f, 0, -160),
            new Vector3(-1.5f, 0, -180),
            new Vector3(-1.5f, 0, -200),
            new Vector3(-1.5f, 0, -220),
            new Vector3(-200, 0, -200),
            new Vector3(-92, 0, -200),
            new Vector3(-92, 0, -175),
            new Vector3(-75, 0, -128.5f),
            new Vector3(-58, 0, -150),
            new Vector3(-80, 0, -112),
            new Vector3(-102, 0, -76),
            new Vector3(-80, 0, -68),
            new Vector3(-57, 0, -90),
            new Vector3(141, 0, -160),
            new Vector3(141, 0, -180),
            new Vector3(141, 0, -200),
            new Vector3(141, 0, -220),
            new Vector3(98.5f, 0, -160),
            new Vector3(98.5f, 0, -180),
            new Vector3(98.5f, 0, -200),
            new Vector3(98.5f, 0, -220),
            new Vector3(110, 0, -128),
            new Vector3(77.5f, 0, -128),
            new Vector3(81, 0, -92),
            new Vector3(102, 0, -59),
            new Vector3(140, 0, -82),
            new Vector3(140, 0, -107),
            new Vector3(120, 0, -28),
            new Vector3(88.5f, 0, -28),
            new Vector3(139, 0, 1),
            new Vector3(139, 0, 26),
            new Vector3(139, 0, 145),
            new Vector3(126, 0, 90),
            new Vector3(-220, 0, 70),
            new Vector3(-176, 0, 149),
            new Vector3(-76, 0, 149),
            new Vector3(-22, 0, 203),
            new Vector3(-45, 0, 203),
            new Vector3(-71, 0, 203),
            new Vector3(-89, 0, 203),
            new Vector3(-137, 0, 203),
            new Vector3(-160, 0, 203),
            new Vector3(-186, 0, 203),
            new Vector3(-220, 0, 224.5f),
            new Vector3(-220, 0, 186.5f),
            new Vector3(-160, 0, 173),
            new Vector3(-131, 0, 173),
            new Vector3(-91, 0, 173),
            new Vector3(-63, 0, 173),
            new Vector3(-41.5f, 0, 173),
            new Vector3(-14.5f, 0, 173),
            new Vector3(176.5f, 0, 187),
            new Vector3(215, 0, 189),
            new Vector3(193, 0, 156),
            new Vector3(193, 0, 130),
            new Vector3(193, 0, 106.5f),
            new Vector3(193, 0, 59.5f),
            new Vector3(193, 0, 41),
            new Vector3(193, 0, 13.5f),
            new Vector3(193, 0, -7.5f),
            new Vector3(160, 0, -15),
            new Vector3(160, 0, 12),
            new Vector3(160, 0, 101),
            new Vector3(160, 0, 33),
            new Vector3(160, 0, 61),
            new Vector3(160, 0, 130)
        };


        ShufflePositions();
        _positions = _positions.Take(10).ToList();

        _stats = FindAnyObjectByType<PlayerStats>();

        InvokeRepeating("UpdateTime", 0f, 1f);
    }

    void ShufflePositions()
    {
        _positions = _positions.OrderBy(pos => Random.value).ToList();
    }

    private void MoveToNextPosition()
    {
        if (AreUndeliveredPizzas())
        {
            transform.position = _positions[0];
            _positions.RemoveAt(0);
        }
        else
        {
            transform.position = new Vector3(115.16f, 35.81f, 289.72f);
            CancelInvoke("UpdateTimer");
            _stats.UpdateRemainingTime(0);
            EndGame();
        }
    }

    private void UpdateTime()
    {
        if (_remainingTime == 0)
        {
            NextDelivery();
        }

        _stats.UpdateRemainingTime(_remainingTime);
        _remainingTime--;
    }
    public void NextDelivery()
    {
        _remainingTime = _deliveryTime;
        _stats.ResetHealth();
        MoveToNextPosition();
    }

    public float GetRemainingTime()
    {
        return _remainingTime;
    }

    public bool AreUndeliveredPizzas()
    {
        return _positions.Count > 0;
    }

    private void EndGame()
    {
        DifficultyManager difficultyManager = FindAnyObjectByType<DifficultyManager>();
        if (difficultyManager != null)
        {
            HighScoreManager highScoreManager = FindAnyObjectByType<HighScoreManager>();
            if (highScoreManager != null)
            {
                highScoreManager.UpdateHighScore(difficultyManager.SelectedDifficulty, Mathf.RoundToInt(_stats.GetCurrentScore()));

                GameManager.Instance.SetStats(_stats.GetCurrentScore(), _stats.GetDeliveredPizzas());

                StartCoroutine(WaitAndLoadScene(0.5f, "GameOverScene"));
            }
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime, string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
