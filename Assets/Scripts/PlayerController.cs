using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    public float Gravity = 9.8f;
    private CharacterController _characterController;
    public float jumpForce = 10f;
    public float Speed = 5f;
    private Vector3 moveVector;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }


    }

    void FixedUpdate()
    {
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        _characterController.Move(moveVector * Speed * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }

    }
}