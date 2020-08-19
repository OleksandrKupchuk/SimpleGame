using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCoordinates : MonoBehaviour
{
    public float positionMinX;
    public float positionMaxX;
    public float positionY;

    //public bool onPlatform;
    //private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        onPlatform = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        onPlatform = false;
    //    }
    //}
}
