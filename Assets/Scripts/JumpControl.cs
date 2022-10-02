using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpControl : MonoBehaviour
{
    private RaycastHit2D[] _hit = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(float jumpForce)
    {
        if (IsGrounded())
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        int _collisionCount = _rigidbody.Cast(Vector2.down, _hit, 0.1f);
        return _collisionCount > 0;
    }
}
