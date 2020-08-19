using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerPosition;

    void Start() => playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

    void Update()
    {
        transform.position = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y + 1, -10);
    }
}
