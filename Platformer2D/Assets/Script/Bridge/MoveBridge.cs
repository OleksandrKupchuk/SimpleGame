using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    [SerializeField] Transform endPosition;
    [SerializeField] Transform startPosition;
    [SerializeField] PressOnPlatform pressOnPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bridge.transform.position.x < endPosition.position.x && pressOnPlatform.press)
        {
            bridge.transform.Translate(bridge.transform.right * Time.deltaTime * 2, endPosition);
        }

        if (bridge.transform.position.x > startPosition.position.x && !pressOnPlatform.press)
        {
            bridge.transform.Translate(-bridge.transform.right * Time.deltaTime * 2, endPosition);
        }

        //Debug.Log("А я виконуюся =)");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //transform.parent = collision.transform;
            collision.transform.SetParent(bridge.transform);
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
