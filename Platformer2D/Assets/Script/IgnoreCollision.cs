using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    //[SerializeField] GameObject playerColliderEdge;
    //Collider2D playerEdge;
    //[SerializeField] Collider2D[] secondIgnoreColliders;

    //Collider2D[] enemyColliders;
    //[SerializeField] GameObject enemy;

    //Collider2D[] playerColliders;
    //[SerializeField] GameObject player;

    void Start()
    {
        //playerEdge = playerColliderEdge.GetComponentInChildren<EdgeCollider2D>();

        //enemyColliders = enemy.GetComponents<Collider2D>();

        //playerColliders = player.GetComponents<Collider2D>();

        //Physics.IgnoreCollision(playerEdge, secondIgnoreColliders, true);

        //for (int i = 0; i < secondIgnoreColliders.Length; i++)
        //{
        //    Physics2D.IgnoreCollision(secondIgnoreColliders[i], playerEdge, true);
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        for (int i = 0; i < enemyColliders.Length; i++)
    //        {
    //            for (int j = 0; j < playerColliders.Length; j++)
    //            {
    //                Physics2D.IgnoreCollision(enemyColliders[i], playerColliders[j]);
    //            }
    //        }
    //    }
    //}
}
