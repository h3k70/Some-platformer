using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _JumpForce = 13f;

    private float _horizontalMove;
    //private BoxCollider2D _collider;
    private MovementControl _movementControl;
    //private RaycastHit2D[] _hit = new RaycastHit2D[1];

    private void Awake()
    {
        //_collider = GetComponent<BoxCollider2D>();
        _movementControl = GetComponent<MovementControl>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal") * _speed;

        //if (Input.GetKeyDown(KeyCode.Space))
        //    Jump();
    }

    private void FixedUpdate()
    {
        _movementControl.Move(_horizontalMove);
    }

    /*private bool IsGrounded()
    {
        Debug.Log(_collider.size.x);
        Debug.Log(_collider.size.y);
        int _collisionCount = _rigidbody.Cast(Vector2.down, _hit, 0.1f);
        return _collisionCount > 0;
    }

    private void Jump()
    {
        if (IsGrounded())
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _JumpForce);
    }
    */
}
