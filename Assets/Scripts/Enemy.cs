using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private MovementControl _movementControl;
    private BoxCollider2D _collider;
    private Vector2 _lowerRightCorner;
    private float _pathCheckDistance = 0.1f;
    private bool _isFlipped = false;
    private int _cornerModifier;

    private void Awake()
    {
        _movementControl = GetComponent<MovementControl>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (IsFreeWay() == false)
            Flip();

        _movementControl.Move(_speed);
    }

    private bool IsFreeWay()
    {
        _cornerModifier =  _isFlipped ? -1 : 1;
        _lowerRightCorner = new Vector2(transform.position.x + (_pathCheckDistance + _collider.size.x * 0.05f) * _cornerModifier, transform.position.y);
        RaycastHit2D hitRight = Physics2D.Raycast(_lowerRightCorner, Vector2.down, 0.1f);

        return (hitRight);
    }

    private void Flip()
    {
        _speed *= -1;
        _isFlipped = !_isFlipped;
    }
}
