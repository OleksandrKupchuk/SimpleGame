using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    void Update()
    {
        if (Player.Instance.shieldDie)
        {
            Destroy(gameObject);
        }
    }
}
