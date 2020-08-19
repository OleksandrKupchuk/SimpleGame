using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] Collider2D enemySign;
    [SerializeField] Collider2D circleCollider;

    Collider2D playerSwordCollider;

    Collider2D[] enemyColliders;
    [SerializeField] GameObject enemy;

    Collider2D[] playerColliders;
    GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        playerSwordCollider = playerObject.transform.GetChild(0).GetComponent<EdgeCollider2D>();

        enemyColliders = enemy.GetComponents<Collider2D>();

        playerColliders = playerObject.GetComponents<Collider2D>();

        Physics2D.IgnoreCollision(playerSwordCollider, enemySign, true);
        Physics2D.IgnoreCollision(playerSwordCollider, circleCollider, true);

        for (int countEnemyCollider = 0; countEnemyCollider < enemyColliders.Length; countEnemyCollider++)
        {
            for (int countPlayerCollider = 0; countPlayerCollider < playerColliders.Length; countPlayerCollider++)
            {
                Physics2D.IgnoreCollision(enemyColliders[countEnemyCollider], playerColliders[countPlayerCollider]);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        for (int countEnemyCollider = 0; countEnemyCollider < enemyColliders.Length; countEnemyCollider++)
    //        {
    //            for (int countPlayerCollider = 0; countPlayerCollider < playerColliders.Length; countPlayerCollider++)
    //            {
    //                Physics2D.IgnoreCollision(enemyColliders[countEnemyCollider], playerColliders[countPlayerCollider]);
    //            }
    //        }
    //    }
    //}
}
