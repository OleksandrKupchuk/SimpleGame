using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySignArcher : MonoBehaviour
{
    [SerializeField] EnemyArcher enemyArcher;

    //[SerializeField] Collider2D colliderSign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyArcher.EnemyTarget = collision.gameObject;
        }

        //if (collision.CompareTag("PlayerSword"))
        //{
        //    Collider2D playerSword;

        //    playerSword = collision.GetComponentInChildren<EdgeCollider2D>();

        //    Physics2D.IgnoreCollision(colliderSign, playerSword, true);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyArcher.EnemyTarget = null;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        enemyArcher.EnemyTarget = collision.gameObject;
    //    }
    //}
}
