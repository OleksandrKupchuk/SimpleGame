using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySignArcher : MonoBehaviour
{
    [SerializeField] EnemyArcher enemyArcher;

    //[SerializeField] float rayDistance;
    //[SerializeField] LayerMask layerMask;
    private void Start()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enemyArcher.CheckCollider(enemyArcher.ChangeSide());
        //if (collision.CompareTag("Player"))
        //{
        //    //enemyArcher.EnemyTarget = collision.gameObject;
        //}
        //Debug.Log("check = " + enemyArcher.CheckCollider());

        //if (enemyArcher.CheckCollider())
        //{
        //    enemyArcher.EnemyTarget = collision.gameObject;
        //}

        //Debug.Log("target = " + EnemyTarget);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyArcher.EnemyTarget = null;
        }
    }

    //public bool CheckCollider(Vector3 direction)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position + transform.localScale.x * direction, rayDistance, layerMask);
    //    return hit;
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance);
    //}
}
