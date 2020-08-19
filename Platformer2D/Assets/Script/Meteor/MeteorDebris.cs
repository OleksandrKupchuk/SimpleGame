using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDebris : MonoBehaviour
{
    [SerializeField] private List<string> ground;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ground.Contains(collision.gameObject.tag))
        {
            gameObject.tag = "Untagged";
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
