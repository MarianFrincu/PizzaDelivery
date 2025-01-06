using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    [SerializeField] private Transform _Player;
    [SerializeField] private Transform _Objective;
    [SerializeField] private float _RotationSpeed = 5f;

    void Update()
    {
        Vector3 directionToTarget = _Objective.position - _Player.position;
        directionToTarget.y = 0;
        directionToTarget.Normalize();

        Quaternion worldTargetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, worldTargetRotation, Time.deltaTime * _RotationSpeed);
    }

}
