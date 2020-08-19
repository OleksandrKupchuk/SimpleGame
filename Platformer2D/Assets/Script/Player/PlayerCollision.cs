using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float axisY;
    public float axisMinX;
    public float axisMaxX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformGround"))
        {
            axisY = collision.gameObject.GetComponent<PlatformCoordinates>().positionY;
            axisMinX = collision.gameObject.GetComponent<PlatformCoordinates>().positionMinX;
            axisMaxX = collision.gameObject.GetComponent<PlatformCoordinates>().positionMaxX;

            //Debug.Log("xMin = " + axisMinX);
            //Debug.Log("xMax = " + axisMaxX);
        }
    }
}
