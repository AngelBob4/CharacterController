using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private float _cameraAngle;
    private float _mouseY;

    private float _verticalSensitivity = 1f;
    private float _verticalMinAngle = -89f;
    private float _verticalMaxAngle = 89f;

    private void Update()
    {
        _cameraAngle -= _mouseY * _verticalSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
    }

    public void SetMouseY(float mouseY)
    {
        _mouseY = mouseY;
    }
}