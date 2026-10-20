using UnityEngine;
using UnityEngine.InputSystem;
using Fusion;
using Unity.VisualScripting;

public class PlayerMovement : NetworkBehaviour {
    private Vector3 _velocity;
    private bool _jumpPressed;

    private CharacterController _controller;

    public Camera cameraP;
    public float PlayerSpeed = 2f;

    public float JumpForce = 10f;
    public float GravityValue = -9.81f;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
    }

    private void Update(){
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            _jumpPressed = true;
        }
    }

    public override void Spawned(){
        if (HasStateAuthority == false){ return; }

        cameraP = Camera.main;
        cameraP.GetComponent<FirstPersonCamera>().Target = transform;
    }

    public override void FixedUpdateNetwork(){
        // FixedUpdateNetwork is only executed on the StateAuthority

        if (_controller.isGrounded){
            _velocity = new Vector3(0, -1, 0);
        }

        Quaternion cameraRotationY = Quaternion.Euler(0, cameraP.transform.rotation.eulerAngles.y, 0);
        Vector3 move = cameraRotationY * new Vector3(Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue(), 0, Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue()) * Runner.DeltaTime * PlayerSpeed;

        _velocity.y += GravityValue * Runner.DeltaTime;

        if (_jumpPressed && _controller.isGrounded){
            _velocity.y += JumpForce;
        }

        _controller.Move(move + _velocity * Runner.DeltaTime);

        gameObject.transform.forward = new Vector3(cameraP.transform.forward.x, 0, cameraP.transform.forward.z).normalized;

        /*if (move != Vector3.zero){
            gameObject.transform.forward = move;
        }*/

        _jumpPressed = false;
    }
}
