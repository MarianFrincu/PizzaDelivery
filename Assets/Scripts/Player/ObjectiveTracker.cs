using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform objective;
    [SerializeField] private float rotationSpeed = 5f;

    void Update()
    {

        Vector3 directionToTarget = objective.position - player.position;
        directionToTarget.y = 0;
        directionToTarget.Normalize();

        Quaternion worldTargetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, worldTargetRotation, Time.deltaTime * rotationSpeed);
    }
}
