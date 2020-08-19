using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyObject : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject, 1.6f);
    }
}
