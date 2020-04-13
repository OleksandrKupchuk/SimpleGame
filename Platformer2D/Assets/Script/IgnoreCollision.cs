using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] Collider2D enemySign;

    Collider2D playerSwordCollider;
    GameObject playerSword;

    Collider2D[] enemyColliders;
    [SerializeField] GameObject enemy;

    Collider2D[] playerColliders;
    GameObject player;

    void Start()
    {
        playerSword = GameObject.FindGameObjectWithTag("PlayerSword");
        player = GameObject.FindGameObjectWithTag("Player");

        playerSwordCollider = playerSword.GetComponent<EdgeCollider2D>();

        enemyColliders = enemy.GetComponents<Collider2D>();

        playerColliders = player.GetComponents<Collider2D>();

        Physics2D.IgnoreCollision(playerSwordCollider, enemySign, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int countEnemyCollider = 0; countEnemyCollider < enemyColliders.Length; countEnemyCollider++)
            {
                for (int countPlayerCollider = 0; countPlayerCollider < playerColliders.Length; countPlayerCollider++)
                {
                    Physics2D.IgnoreCollision(enemyColliders[countEnemyCollider], playerColliders[countPlayerCollider]);
                }
            }
        }
    }
}
