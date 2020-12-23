using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private Vector2 forceDirection;
    private Rigidbody2D rigidbody;

    void Start()
    {
        float randomForceX = Random.Range(-0.5f, 0.5f);
        float randomForceY = Random.Range(0.1f, 0.5f);

        forceDirection = new Vector2(randomForceX, randomForceY);

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
        rigidbody.AddTorque(torque);
    }
}
