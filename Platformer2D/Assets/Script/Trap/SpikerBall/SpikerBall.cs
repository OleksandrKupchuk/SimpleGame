using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerBall : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private int speed;

    void Update()
    {
        transform.RotateAround(center.transform.position, center.transform.forward, speed * Time.deltaTime);
    }
}
