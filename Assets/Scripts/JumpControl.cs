using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    private BoxCollider2D _collider;
    private RaycastHit2D[] _hit = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody;

    public void Jump(float jumpForce)
    {
        if (IsGrounded())
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private bool IsGrounded()
    {
        Debug.Log(_collider.size.x);
        Debug.Log(_collider.size.y);
        int _collisionCount = _rigidbody.Cast(Vector2.down, _hit, 0.1f);
        return _collisionCount > 0;
    }
}
