using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    [SerializeField] EnemyArcher archer;
    public float distance;
    RaycastHit2D hitInfo;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region blackborn
        if (archer.facingRight)
        {
            hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance);
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                if (hitInfo.collider.CompareTag("Player"))
                {
                    archer.EnemyTarget = player;
                    
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + Vector3.right * distance, Color.green);
                archer.EnemyTarget = null;
            }
        }
        else if(!archer.facingRight)
        {
            hitInfo = Physics2D.Raycast(transform.position, Vector2.left, distance);

            if (hitInfo.collider != null)
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                if (hitInfo.collider.CompareTag("Player"))
                {
                    archer.EnemyTarget = player;
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + Vector3.left * distance, Color.green);
                archer.EnemyTarget = null;
            }
        }
        #endregion
    }
}
