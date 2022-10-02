using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private HashAnimationCoin _animationCoin = new HashAnimationCoin();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetTrigger(_animationCoin.Picked);
            Destroy(gameObject, _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }
    }
}