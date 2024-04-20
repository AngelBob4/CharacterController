using UnityEngine;

[RequireComponent(typeof(PlayerMovement))] 
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCameraRotation _playerCameraRotation;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCameraRotation = GetComponent<PlayerCameraRotation>();    
    }

    private void Update()
    {
        _playerMovement.SetAxises(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.Rotate(Input.GetAxis("Mouse X"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMovement.Jump();
        }

        _playerCameraRotation.SetMouseY(Input.GetAxis("Mouse Y"));
    }
}