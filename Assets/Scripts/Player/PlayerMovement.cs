using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MaxSpeed = 30f;
    [SerializeField] private float _ReverseSpeed = 5f;
    [SerializeField] private float _Acceleration = 8f;
    [SerializeField] private float _Deceleration = 10f;
    [SerializeField] private float _RotationSpeed = 180f;
    [SerializeField] private Transform _SteeringHelper;
    [SerializeField] private float _MinYPosition = 0f;

    private Rigidbody _rb;
    private float _currentSpeed = 0f;
    private bool _isReversing = false;

    private PlayerStats _stats;

    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    private AudioSource _audioSource;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private Vector3 _initialCameraPosition;
    private Quaternion _initialCameraRotation;

    private bool isInputEnabled = true;

    private Camera _camera;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _stats = GetComponent<PlayerStats>();
        _camera = GetComponentInChildren<Camera>();
        _audioSource = GetComponent<AudioSource>();

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _initialCameraPosition = _camera.transform.localPosition;
        _initialCameraRotation = _camera.transform.localRotation;

        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void FixedUpdate()
    {
        if (!isInputEnabled)
            return;

        Move();
        RotateHandlebars();
        PreventOutOfMap();
    }

    private void Move()
    {

        float forwardInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            forwardInput = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            forwardInput = -1f;
        }

        _isReversing = _currentSpeed < 0;

        if (forwardInput > 0)
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, forwardInput * _MaxSpeed, _Acceleration * Time.fixedDeltaTime);
        }
        else if (forwardInput < 0)
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, forwardInput * _ReverseSpeed, _Acceleration * Time.fixedDeltaTime);
        }
        else
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, 0, _Deceleration * Time.fixedDeltaTime);
        }

        Vector3 forwardMovement = transform.forward * _currentSpeed * Time.fixedDeltaTime;

        _rb.MovePosition(_rb.position + forwardMovement);

        if (Input.GetKey(KeyCode.LeftArrow))
            RotateVehicle(-1);
        else if (Input.GetKey(KeyCode.RightArrow))
            RotateVehicle(1);
    }

    private void RotateVehicle(float direction)
    {
        float rotationFactor = Mathf.Clamp01(Mathf.Abs(_currentSpeed) / _MaxSpeed);
        float rotationDirection = _isReversing ? -1 : 1;
        Quaternion deltaRotation = Quaternion.Euler(0, rotationDirection * direction * _RotationSpeed * rotationFactor * Time.fixedDeltaTime, 0);
        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }

    private void RotateHandlebars()
    {
        float targetZ = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            targetZ = -35;
        else if (Input.GetKey(KeyCode.RightArrow))
            targetZ = 35;

        Vector3 targetEulerAngles = new Vector3(
            _SteeringHelper.localEulerAngles.x,
            _SteeringHelper.localEulerAngles.y,
            Mathf.Lerp(NormalizeAngle(_SteeringHelper.localEulerAngles.z), targetZ, Time.fixedDeltaTime * 5f)
        );

        _SteeringHelper.localEulerAngles = targetEulerAngles;
    }

    private void PreventOutOfMap()
    {
        if (transform.position.y < _MinYPosition)
        {
            Vector3 newPosition = _rb.position;
            newPosition.y = _MinYPosition;
            _rb.MovePosition(newPosition);
        }
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180) angle -= 360;
        if (angle < -180) angle += 360;
        return angle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ApplyDamage();

            _rb.MovePosition(_rb.position - transform.forward * 0.07f);

            _currentSpeed = 0;
            _rb.linearVelocity = Vector3.zero;
        }
    }

    private void ApplyDamage()
    {
        int damage = Mathf.RoundToInt(40 * (Mathf.Exp(3* Mathf.Abs(_currentSpeed) / 30) - 1) / (Mathf.Exp(3) - 1));

        _stats.UpdateHealth(damage);

        if (_stats.GetCurrentHealth() == 0)
        {
            HandleDeath();
        }

    }

    private void HandleDeath()
    {
        TriggerExplosion();
        transform.position += new Vector3(0, -10, 0);
        _camera.transform.localPosition = new Vector3(0, 12, -4);
        _camera.transform.localRotation = Quaternion.Euler(45, 0, 0);
        _rb.useGravity = false;
        FindAnyObjectByType<ObjectiveRelocator>().ReverseTimer(3);
        isInputEnabled = false;
        Invoke("ResetPos", 2f);
    }

    private void ResetPos()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        _camera.transform.localPosition = _initialCameraPosition;
        _camera.transform.localRotation = _initialCameraRotation;
        isInputEnabled = true;
        _rb.useGravity = true;
        FindAnyObjectByType<ObjectiveRelocator>().NextDelivery();
    }

    public void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        if (_audioSource != null && explosionSound != null)
        {
            _audioSource.PlayOneShot(explosionSound);
        }
    }
    
}
