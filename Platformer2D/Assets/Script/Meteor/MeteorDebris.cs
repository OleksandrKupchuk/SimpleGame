using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDebris : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private List<string> ground;

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log($"{gameObject.name} - Rid = " + rigidbody.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ground.Contains(collision.gameObject.tag))
        {
            //Debug.Log("touch");
            gameObject.tag = "Untagged";
        }
    }
}
