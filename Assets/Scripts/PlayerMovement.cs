using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _direction;

    [Header("Input")]
    [SerializeField]
    private KeyCode _jumpKey;

    [Header("Physics")]
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 7f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(x, 0, z);

        if (Input.GetKeyDown( _jumpKey ))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        if(_direction.sqrMagnitude != 0)
        {
            Movement(_direction);
        }
    }

    private void Movement(Vector3 direction)
    {
        _rb.MovePosition(transform.position + direction.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.VelocityChange);
    }
}
