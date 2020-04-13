using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySignArcher : MonoBehaviour
{
    [SerializeField] EnemyArcher enemyArcher;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyArcher.EnemyTarget = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyArcher.EnemyTarget = null;
        }
    }
}
