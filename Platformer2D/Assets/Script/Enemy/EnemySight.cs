using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField] EnemySwordman enemySwordman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemySwordman.EnemyTarget = collision.gameObject;
        }

        if (collision.CompareTag("PlayerSword"))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemySwordman.EnemyTarget = null;
        }
    }
}
