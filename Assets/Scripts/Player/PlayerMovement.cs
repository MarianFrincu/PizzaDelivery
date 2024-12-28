using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _RotationSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += _MovementSpeed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += _MovementSpeed * Time.deltaTime * -transform.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles += _RotationSpeed * Time.deltaTime * Vector3.down;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles += _RotationSpeed * Time.deltaTime * Vector3.up;
        }
    }
}
