using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _JumpForce = 13f;

    private MovementControl _movementControl;
    private JumpControl _jumpControl;
    private Animator _animator;
    private HashAnimationRogue _animationRogue = new HashAnimationRogue();
    private bool _isDead = false;
    private float _horizontalMove;

    private void Awake()
    {
        _movementControl = GetComponent<MovementControl>();
        _jumpControl = GetComponent<JumpControl>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isDead == false)
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
                _jumpControl.Jump(_JumpForce);
        }
    }

    private void FixedUpdate()
    {
        _movementControl.Move(_horizontalMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && _isDead == false)
        {
            _animator.SetTrigger(_animationRogue.Dead);
            _isDead = true;
            _horizontalMove = 0;
        }
    }
}
