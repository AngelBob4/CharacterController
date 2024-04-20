using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private float _jumpSpeed = 7f;
    private float _rotationSpeed = 1f;

    private Vector3 _verticalVelocity = Vector3.zero;
    private Vector3 _horizontalVelocity = Vector3.zero;
    private bool _jumping;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void SetAxises(float horizontalValue, float verticalValue)
    {
        Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized;
        _horizontalVelocity = (forward * verticalValue + right * horizontalValue) * _moveSpeed;
    }

    public void Jump()
    {
        _jumping = true;
    }

    public void Rotate(float mouseY)
    {
        transform.Rotate(Vector3.up * _rotationSpeed * mouseY);
    }

    private void Move()
    {
        if (_characterController.isGrounded)
        {
            if (_jumping)
            {
                _verticalVelocity = Vector3.up * _jumpSpeed;
            }
            else
            {
                _verticalVelocity = Vector3.down;
            }

            _characterController.Move((_horizontalVelocity + _verticalVelocity) * Time.deltaTime);
        }
        else
        {
            _jumping = false;
            Vector3 horizontalVelocity = _horizontalVelocity;
            horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * Time.deltaTime;
            _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
        }
    }
}