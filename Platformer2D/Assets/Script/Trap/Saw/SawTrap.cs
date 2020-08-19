using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private EnemyDamage damageObject;

    [Header("Start direction for X-right(true)/left(false) | Y-up(true)/down(false)")]
    [SerializeField] private bool isRight;

    [Header("Speed")]
    [SerializeField] private float speed;

    [Header("Distance")]
    [SerializeField] private float distance;

    [Header("Axis direction X-true/Y-false")]
    [SerializeField] private bool directionAxis;
    private float min;
    private float max;

    bool Max
    {
        get
        {
            return transform.position.x > max;
        }
    }

    bool Min
    {
        get
        {
            return transform.position.x < min;
        }
    }

    void Start()
    {
        if(directionAxis)
        {
            min = transform.localPosition.x - distance;
            max = transform.localPosition.x + distance;
        }

        if (!directionAxis)
        {
            min = transform.localPosition.y - distance;
            max = transform.localPosition.y + distance;
        }
        
    }

    
    void Update()
    {
        //Debug.Log("min = " + Min);
        //Debug.Log("max = " + Max);
        //Debug.Log("trans = " + transform.position.x);

        if (directionAxis)
        {
            MoveTrap(Vector3.right, Vector3.left, transform.position.x);
        }

        if (!directionAxis)
        {
            MoveTrap(Vector3.up, Vector3.down, transform.position.y);
        }
    }

    private void MoveTrap(Vector3 firstDirection, Vector3 secondDirection, float posittion)
    {
        if (posittion < min)
        {
            isRight = true;
        }

        else if (posittion > max)
        {
            isRight = false;
        }

        if (isRight)
        {
            transform.Translate(firstDirection * Time.deltaTime * speed);
            //Debug.Log("1");
        }

        if (!isRight)
        {
            transform.Translate(secondDirection * Time.deltaTime * speed);
            //Debug.Log("2");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!Player.PlayerInstance.PlayerBlink)
            {
                StartCoroutine(Player.PlayerInstance.TakeDamage(damageObject.damage));
            }
        }
    }
}
