using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyArrowMove : MonoBehaviour
{
    [SerializeField] private float speedArrow;
    [SerializeField] private Rigidbody2D arrowRigidbody2d;
    [SerializeField] private SpriteRenderer sprite;

    Vector2 arrowDirection;

    //void Start()
    //{
    //    arrowRigidbody2d.velocity = transform.right * speedArrow;
    //}

    private void FixedUpdate()
    {
        arrowRigidbody2d.velocity = arrowDirection * speedArrow;
    }

    public void ArrowInitialization(Vector2 direction)
    {
        arrowDirection = direction;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.enabled = false;
        Destroy(gameObject, 1f);
        //if (collision.comparetag("playershield"))
        //{
        //    destroy(gameobject);
        //}
    }
}
