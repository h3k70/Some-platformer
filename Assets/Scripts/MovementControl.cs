using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MovementControl : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private HashAnimationRogue _animationRogue = new HashAnimationRogue();
    private Quaternion _rightRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion _leftRotation = new Quaternion(0, 180, 0, 0);
    private Vector2 _targetVelocity;

    public void Move(float horizontalMove)
    {
        _targetVelocity = new Vector2(horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = _targetVelocity;

        if (horizontalMove > 0)
        {
            _animator.SetBool(_animationRogue.IsMoving, true);
            _transform.rotation = _rightRotation;
        }
        else if (horizontalMove < 0)
        {
            _animator.SetBool(_animationRogue.IsMoving, true);
            _transform.rotation = _leftRotation;
        }
        else
        {
            _animator.SetBool(_animationRogue.IsMoving, false);
        }
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
}
