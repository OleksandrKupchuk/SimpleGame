using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Collider2D playerCollider;
    private Collider2D playerColliderCircle;

    [SerializeField] Collider2D platformCollider;
    [SerializeField] Collider2D platformTrigger;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        playerColliderCircle = GameObject.Find("Player").GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, playerCollider, true);

        //Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(platformCollider, playerColliderCircle, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(platformCollider, playerColliderCircle, false);
        }
    }
}
