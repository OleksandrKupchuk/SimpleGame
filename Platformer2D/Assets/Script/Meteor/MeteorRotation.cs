using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    [System.Obsolete]
    void Update()
    {
        transform.RotateAroundLocal(Vector3.forward, 30);
    }
}
