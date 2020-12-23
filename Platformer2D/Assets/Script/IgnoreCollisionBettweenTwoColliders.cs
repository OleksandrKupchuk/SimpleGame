using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionBettweenTwoColliders : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    private Collider2D playerCircleCollider;
    private Collider2D playerSword;
    private GameObject playerObject;
    [SerializeField] private bool childCollider;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if (!childCollider)
        {
            playerCircleCollider = playerObject.GetComponent<CircleCollider2D>();
            Physics2D.IgnoreCollision(collider, playerCircleCollider, true);
        }

        if (childCollider)
        {
            playerCircleCollider = playerObject.transform.GetChild(0).GetComponent<EdgeCollider2D>();
            Physics2D.IgnoreCollision(collider, playerCircleCollider, true);
        }
    }
}
