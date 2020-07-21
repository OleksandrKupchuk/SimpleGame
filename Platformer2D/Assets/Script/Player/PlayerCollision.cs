using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float axisY;
    private float axisX;
    public float targetX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformGround"))
        {
            axisY = collision.gameObject.transform.position.y;
            axisX = collision.gameObject.transform.position.x;
            targetX = Random.Range(axisX - 2f, axisX + 2f);
        }
    }
}
