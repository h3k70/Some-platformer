using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _JumpForce = 13f;

    private float _horizontalMove;
    private MovementControl _movementControl;
    private JumpControl _jumpControl;

    private void Awake()
    {
        _movementControl = GetComponent<MovementControl>();
        _jumpControl = GetComponent<JumpControl>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal") * _speed;

        if (Input.GetKeyDown(KeyCode.Space))
            _jumpControl.Jump(_JumpForce);
    }

    private void FixedUpdate()
    {
        _movementControl.Move(_horizontalMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {

        }
    }
}
