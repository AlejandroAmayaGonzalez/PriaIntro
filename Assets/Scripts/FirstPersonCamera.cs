using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour {
    public Transform Target;
    public float MouseSensitivity = 0.1f;

    private float _verticalRotation;
    private float _horizontalRotation;

    private void LateUpdate(){
        if (Target == null)
            return;

        transform.position = Target.position;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        _verticalRotation -= mouseDelta.y * MouseSensitivity;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -70f, 70f);

        _horizontalRotation += mouseDelta.x * MouseSensitivity;

        transform.rotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0);
    }
}