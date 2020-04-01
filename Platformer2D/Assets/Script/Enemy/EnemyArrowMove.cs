using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyArrowMove : MonoBehaviour
{
    [SerializeField] float speedArrow;
    [SerializeField] Rigidbody2D arrowRigidbody2d;

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
}
