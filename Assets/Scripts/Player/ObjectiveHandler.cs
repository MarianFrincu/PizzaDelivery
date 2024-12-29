using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    private int _score;

    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        
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
}
