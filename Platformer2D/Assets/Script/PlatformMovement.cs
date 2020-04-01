using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 nextPosition;
    private Vector3 firstPosition;
    private Vector3 secondPosition;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;
    [SerializeField] float speedPlatform;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = startPosition.localPosition;
        secondPosition = endPosition.localPosition;
        nextPosition = secondPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("start = " + startPosition.localPosition);
        //Debug.Log("first = " + firstPosition);
        //Debug.Log("second = " + secondPosition);
        //Debug.Log("next = " + nextPosition);
        MovePlatform();
    }

    private void MovePlatform()
    {
        startPosition.localPosition = Vector3.MoveTowards(startPosition.localPosition, nextPosition, speedPlatform * Time.deltaTime);

        if(Vector3.Distance(startPosition.localPosition, nextPosition) < 0.1f)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        nextPosition = nextPosition != firstPosition ? firstPosition : secondPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //transform.parent = collision.transform;
            collision.transform.SetParent(startPosition);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //transform.parent = null;
            collision.transform.SetParent(null);
        }
    }
}
